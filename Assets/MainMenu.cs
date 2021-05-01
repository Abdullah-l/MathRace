using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    TMP_InputField studentName;

    public GameObject playBtn;

    public GameObject quitBtn;

    public GameObject InstrBtn;

    public GameObject myScoresBtn;

    public GameObject logOutBtn;

    public TMP_Text userWelcome;



    DBConnector dBConn;

    void Start()
    {
        dBConn = GameObject.Find("DB Connect").GetComponent<DBConnector>();

        if (!string.IsNullOrEmpty(dBConn.studentName))
        {
            LoggedIn();
        }
    }
    public void SubmitName()
    {

        studentName = GameObject.Find("Student Name").GetComponent<TMP_InputField>();
        TMP_Text warnUser = GameObject.Find("WarnUser").GetComponent<TMP_Text>();
        // studentName.ActivateInputField();


        if (string.IsNullOrEmpty(studentName.text))
        {
            studentName.ActivateInputField();
            warnUser.text = "You must have a name, duh!";
            return;
        }
        dBConn.studentName = studentName.text;
        dBConn.InsertStudent();

        studentName.gameObject.SetActive(false);
        GameObject.Find("TextCanvas").SetActive(false);
        playBtn.SetActive(true);
        myScoresBtn.SetActive(true);

        GameObject.Find("Go Button").SetActive(false);
        userWelcome.text = "Logged-in as: " + dBConn.studentName;
        logOutBtn.SetActive(true);

    }

    public void LoggedIn()
    {

        studentName = GameObject.Find("Student Name").GetComponent<TMP_InputField>();
        TMP_Text warnUser = GameObject.Find("WarnUser").GetComponent<TMP_Text>();


        studentName.gameObject.SetActive(false);
        GameObject.Find("TextCanvas").SetActive(false);
        playBtn.SetActive(true);
        myScoresBtn.SetActive(true);

        GameObject.Find("Go Button").SetActive(false);
        userWelcome.text = "Logged-in as: " + dBConn.studentName;
        logOutBtn.SetActive(true);


    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelChoice");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void InstrBtnClick()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void toPortal()
    {
        SceneManager.LoadScene("TeacherPortal");
    }
    public void toMyScores()
    {
        SceneManager.LoadScene("MyScores");
    }

    public void logOutClick()
    {
        userWelcome.text = "";
        dBConn.studentName = "";
        SceneManager.LoadScene("Main menu");
    }
}
