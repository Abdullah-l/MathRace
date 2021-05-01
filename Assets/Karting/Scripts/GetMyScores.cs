using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GetMyScores : MonoBehaviour
{

    DBConnector dbConn;

    public GameObject AfterLogin;
    TMP_Text scores;
    void Start()
    {
        dbConn = GameObject.Find("DB Connect").GetComponent<DBConnector>();
        scores = AfterLogin.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>();

        scores.text = dbConn.getMyScores(0);
        if (string.IsNullOrEmpty(scores.text)){
            scores.text = "You haven't played the game yet. Play the game to see some scores!";
            AfterLogin.transform.Find("Dropdown").gameObject.SetActive(false);
        }
    }

    public void sortDrop(int val)
    {
        scores.text = dbConn.getMyScores(val);
    }
    public void BackToMenuClick()
    {
        SceneManager.LoadScene("Main menu");

    }
}
