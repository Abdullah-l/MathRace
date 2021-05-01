using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EOL : MonoBehaviour
{
    public TextMeshProUGUI EOLmessage;
    public Text Time;
    DBConnector dBConn;


    void Start()
    {
        Text levelText = GameObject.Find("Level text").GetComponent<Text>();
        CubeCounter cs = GameObject.Find("Kart").GetComponent<CubeCounter>();
        TimeOnScreen ts = GameObject.Find("TimeObject").GetComponent<TimeOnScreen>();
        dBConn = GameObject.Find("DB Connect").GetComponent<DBConnector>();
        int score = 0;
        if (levelText.text == "Level 1")
        {
            score = (int)(50 * Math.Pow(0.99, (ts.gameTimer - 20)) + 50 * Math.Pow(0.9, (cs.wrongCounter - 1)));
        }
        else if (levelText.text == "Level 2")
        {
            score = (int)(50 * Math.Pow(0.99, (ts.gameTimer - 25)) + 50 * Math.Pow(0.9, (cs.wrongCounter - 1)));
        }
        else if (levelText.text == "Level 3")
        {
            score = (int)(50 * Math.Pow(0.99, (ts.gameTimer - 30)) + 50 * Math.Pow(0.9, (cs.wrongCounter - 1)));
        }
        else if (levelText.text == "Level 4")
        {
            score = (int)(50 * Math.Pow(0.99, (ts.gameTimer - 35)) + 50 * Math.Pow(0.9, (cs.wrongCounter - 1)));
        }
        else if (levelText.text == "Level 5")
        {
            score = (int)(50 * Math.Pow(0.99, (ts.gameTimer - 40)) + 50 * Math.Pow(0.9, (cs.wrongCounter - 1)));
        }
        if(score > 100){
            score = 100;
        }
        EOLmessage.text = "Time: " + Time.text + "\nTotal Incorrect Answers: " + cs.wrongCounter + "\nScore: " + score + "/100";
        dBConn.InsertScore(cs.wrongCounter, Time.text, score, levelText.text);

    }

    public void QuitBtnClick()
    {
        Application.Quit();
    }

    public void RestartBtnClick()
    {
        SceneManager.LoadScene("Main menu");
    }
}
