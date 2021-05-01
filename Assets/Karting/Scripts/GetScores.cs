using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GetScores : MonoBehaviour
{

    DBConnector dbConn;

    public GameObject AfterLogin;
    TMP_Text scores;
    void Start()
    {
        dbConn = GameObject.Find("DB Connect").GetComponent<DBConnector>();
        scores = AfterLogin.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>();

        scores.text = dbConn.getScores(0);
    }

    public void sortDrop(int val)
    {
        scores.text = dbConn.getScores(val);
    }
    public void LoginClick()
    {
        TMP_InputField username = GameObject.Find("Username").GetComponent<TMP_InputField>();
        TMP_InputField pass = GameObject.Find("Pass").GetComponent<TMP_InputField>();

        TMP_Text warnTeacher = GameObject.Find("WarnTeacher").GetComponent<TMP_Text>();


        if (username.text != "teacher1" || pass.text != "password2")
        {
            warnTeacher.text = "Incorrect Username Or Password. Try Again!";
            return;
        }

        AfterLogin.SetActive(true);
        GameObject.Find("LoginCanvas").SetActive(false);

    }

    public void BackToMenuClick()
    {
        SceneManager.LoadScene("Main menu");

    }
}
