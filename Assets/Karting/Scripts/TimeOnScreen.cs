using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOnScreen : MonoBehaviour
{
    public Text gameTimerText;
    public float gameTimer = 0f;
    public GameObject go;
    bool gotit = false;

    void Start()
    {
        gameTimerText.text = "00:00";
        //go = GameObject.Find("GoText");
    }
    void Update()
    {
        if (go.activeInHierarchy && !gotit)
        {
            gotit = true;
        }
        if (gotit)
        {
            gameTimer += Time.deltaTime;
            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            gameTimerText.text = timerString;
        }
    }
}
