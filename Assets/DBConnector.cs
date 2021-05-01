using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;
using System.Linq;
//using NUnit.Framework;
public class DBConnector : MonoBehaviour
{
    //private SQLiteConnection connection;

    public string studentName;
    //private SQLiteCommand command;
    private SQLiteConnection connection;

    private string DatabaseName = "MathRaceDB.db";

    public void SetConnection()
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format(Application.dataPath + "/StreamingAssets/" + DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

    }
    void Start()
    {

        // SQLiteCommand command = connection.CreateCommand();
        // command.CommandType = System.Data.CommandType.Text;
        // command.CommandText = "CREATE TABLE IF NOT EXISTS 'highscores' ( " +
        //                   "  'id' INTEGER PRIMARY KEY, " +
        //                   "  'name' TEXT NOT NULL, " +
        //                   "  'score' INTEGER NOT NULL" +
        //                   ");";
        // command.ExecuteNonQuery();
        // connection.Close();
        AudioListener.volume = 0f;
        DontDestroyOnLoad(this.gameObject);

        SetConnection();
        SQLiteCommand student = connection.CreateCommand("CREATE TABLE IF NOT EXISTS Student ( 'name' VARCHAR(64) PRIMARY KEY );");
        //student.CommandText = "CREATE TABLE IF NOT EXISTS Student ( 'name' VARCHAR(64) PRIMARY KEY );";
        student.ExecuteNonQuery();

        SQLiteCommand score = connection.CreateCommand("CREATE TABLE IF NOT EXISTS Score ( 'id' Integer PRIMARY KEY AUTOINCREMENT, 'totalWrong' Integer, 'studentName' varchar(64), 'dt' DATE DEFAULT (datetime('now','localtime')), 'gameTime' varchar(16), 'gameScore' Integer, 'levelNum' varchar(16), FOREIGN KEY (studentName) REFERENCES Student (name) );");
        //score.CommandText = "CREATE TABLE IF NOT EXISTS Score ( 'id' Integer PRIMARY KEY AUTOINCREMENT, 'totalWrong' InTeger, 'studentName' varchar(64), dt dt DATE DEFAULT (datetime('now','localtime')), FOREIGN KEY (studentName) REFERENCES Student (name) );";
        score.ExecuteNonQuery();

        connection.Close();
    }

    public void InsertStudent()
    {
        SetConnection();
        SQLiteCommand student = connection.CreateCommand("INSERT OR REPLACE INTO Student VALUES (?);", studentName);
        //student.CommandText = "INSERT OR REPLACE INTO Student VALUES (@studentName);";
        //student.Parameters.AddWithValue("studentName", studentName);
        student.ExecuteNonQuery();
        connection.Close();
    }

    public void InsertScore(int totalWrong, string gameTime, int gameScore, string levelNum)
    {
        SetConnection();
        SQLiteCommand insrSc = connection.CreateCommand("INSERT OR REPLACE INTO Score (totalWrong, studentName, gameTime, gameScore, levelNum) VALUES (?, ?, ?, ?, ?);", new object[] { totalWrong, studentName, gameTime, gameScore, levelNum });
        //score.CommandText = " INSERT OR REPLACE INTO Score (totalWrong, studentName) VALUES (@totalWrong, @studentName);";
        //score.Parameters.AddWithValue("totalWrong", totalWrong);
        //score.Parameters.AddWithValue("studentName", studentName);
        insrSc.ExecuteNonQuery();
        connection.Close();
    }
    public class Res
    {
        public string name { get; set; }
        public string dt { get; set; }
        public int totalWrong { get; set; }
        public string gameTime { get; set; }
        public int gameScore { get; set; }

        public string levelNum { get; set; }



    }
    public string getScores(int val)
    {
        SetConnection();

        var query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, dt DESC;");
        if (val == 0)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, dt DESC;");
        }
        else if (val == 1)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, dt;");
        }
        else if (val == 2)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, gameScore DESC;");
        }
        else if (val == 3)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, gameScore;");
        }
        else if (val == 4)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, gameTime;");
        }
        else if (val == 5)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, gameTime DESC;");
        }
        else if (val == 6)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, name;");
        }
        else if (val == 7)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore, levelNum FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                ORDER BY levelNum, name DESC;");
        }

        string line = "";


        foreach (var read in query)
        {
            line += read.name + "\n";
            line += read.levelNum + "\n";
            line += "Date of Attempt: " + read.dt + "\n";
            line += "Total Incorrect Answers: " + read.totalWrong + "\n";
            line += "Total Time: " + read.gameTime + "\n";
            line += "Score: " + read.gameScore + "/100\n\n";
        }
        connection.Close();
        return line;
    }

    public string getMyScores(int val)
    {
        SetConnection();

        var query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY dt DESC;", studentName);
        if (val == 0)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY dt DESC;", studentName);
        }
        else if (val == 1)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY dt;", studentName);
        }
        else if (val == 2)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY gameScore DESC;", studentName);
        }
        else if (val == 3)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY gameScore;", studentName);
        }
        else if (val == 4)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY gameTime;", studentName);
        }
        else if (val == 5)
        {
            query = connection.Query<Res>(@"SELECT name, dt, totalwrong, gameTime, gameScore FROM Student 
                                INNER JOIN Score ON Score.studentname = Student.name
                                WHERE name = ?
                                ORDER BY gameTime DESC;", studentName);
        }


        string line = "";


        foreach (var read in query)
        {
            line += read.name + "\n";
            line += "Date of Attempt: " + read.dt + "\n";
            line += "Total Incorrect Answers: " + read.totalWrong + "\n";
            line += "Total Time: " + read.gameTime + "\n";
            line += "Score: " + read.gameScore + "/100\n\n";
        }
        connection.Close();
        return line;
    }
}