using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;


public class CubeCounter : MonoBehaviour
{
    public Text cubes;
    public int i;
    public GameObject canvas;

    public int wrongCounter = 0;

    public int iDefault;

    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Cube")
        {
            i--;
            // if (i == 9){
            //   //canvas = GameObject.Find("EndOfLevel");
            //   canvas.SetActive(true);
            // }
            // cubes.text = "Cubes left: " + i + "/10";
        }
    }
}

