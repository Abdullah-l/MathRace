using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using TMPro;


namespace KartGame.KartSystems
{
    public class ColorChanger : MonoBehaviour
    {

        public void changeSpeed(int val)
        {
            GameObject kart = GameObject.Find("Kart");
            switch (val)
            {
                case 0:
                    kart.GetComponent<KartMovement>().defaultStats.acceleration = 5f;
                    kart.GetComponent<KartMovement>().defaultStats.topSpeed = 25f;
                    break;

                case 1:
                    kart.GetComponent<KartMovement>().defaultStats.acceleration = 10f;
                    kart.GetComponent<KartMovement>().defaultStats.topSpeed = 30f;
                    break;

                case 2:
                    kart.GetComponent<KartMovement>().defaultStats.acceleration = 15f;
                    kart.GetComponent<KartMovement>().defaultStats.topSpeed = 35f;
                    break;

            }
        }

        public void changeArena(int val)
        {
            GameObject gp = GameObject.Find("GroundPlane");
            switch (val)
            {
                case 0:
                    gp.GetComponent<Renderer>().material.color = Color.white;
                    break;
                case 1:
                    gp.GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 2:
                    gp.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 3:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    break;
                case 4:
                    gp.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 5:
                    gp.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 6:
                    gp.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    break;
                case 7:
                    gp.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    break;
                case 8:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    break;
                case 9:
                    gp.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    break;
            }
        }

        public void changeWall(int val)
        {
            GameObject gp = GameObject.Find("Horizon");
            switch (val)
            {
                case 0:
                    gp.GetComponent<Renderer>().material.color = Color.white;
                    break;
                case 1:
                    gp.GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 2:
                    gp.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 3:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    break;
                case 4:
                    gp.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 5:
                    gp.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 6:
                    gp.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    break;
                case 7:
                    gp.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    break;
                case 8:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    break;
                case 9:
                    gp.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    break;
            }
        }

        public void changeKartBody(int val)
        {
            GameObject gp = GameObject.Find("Kart_Body");
            switch (val)
            {
                case 0:
                    gp.GetComponent<Renderer>().material.color = Color.white;
                    break;
                case 1:
                    gp.GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 2:
                    gp.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 3:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    break;
                case 4:
                    gp.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 5:
                    gp.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 6:
                    gp.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    break;
                case 7:
                    gp.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    break;
                case 8:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    break;
                case 9:
                    gp.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    break;
            }
        }

        public void changeKartWheels(int val)
        {
            GameObject fl = GameObject.Find("WheelFrontLeft");
            GameObject fr = GameObject.Find("WheelFrontRight");
            GameObject rl = GameObject.Find("WheelRearLeft");
            GameObject rr = GameObject.Find("WheelRearRight");
            switch (val)
            {
                case 0:
                    fl.GetComponent<Renderer>().material.color = Color.white;
                    fr.GetComponent<Renderer>().material.color = Color.white;
                    rl.GetComponent<Renderer>().material.color = Color.white;
                    rr.GetComponent<Renderer>().material.color = Color.white;
                    break;
                case 1:
                    fl.GetComponent<Renderer>().material.color = Color.gray;
                    fr.GetComponent<Renderer>().material.color = Color.gray;
                    rl.GetComponent<Renderer>().material.color = Color.gray;
                    rr.GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 2:
                    fl.GetComponent<Renderer>().material.color = Color.red;
                    fr.GetComponent<Renderer>().material.color = Color.red;
                    rl.GetComponent<Renderer>().material.color = Color.red;
                    rr.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 3:
                    fl.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    fr.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    rl.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    rr.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    break;
                case 4:
                    fl.GetComponent<Renderer>().material.color = Color.yellow;
                    fr.GetComponent<Renderer>().material.color = Color.yellow;
                    rl.GetComponent<Renderer>().material.color = Color.yellow;
                    rr.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 5:
                    fl.GetComponent<Renderer>().material.color = Color.green;
                    fr.GetComponent<Renderer>().material.color = Color.green;
                    rl.GetComponent<Renderer>().material.color = Color.green;
                    rr.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 6:
                    fl.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    fr.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    rl.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    rr.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    break;
                case 7:
                    fl.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    fr.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    rl.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    rr.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    break;
                case 8:
                    fl.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    fr.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    rl.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    rr.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    break;
                case 9:
                    fl.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    fr.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    rl.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    rr.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    break;
            }
        }

        public void changePerson(int val)
        {
            GameObject gp = GameObject.Find("Template_Character");
            switch (val)
            {
                case 0:
                    gp.GetComponent<Renderer>().material.color = Color.white;
                    break;
                case 1:
                    gp.GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 2:
                    gp.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 3:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 1);
                    break;
                case 4:
                    gp.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 5:
                    gp.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 6:
                    gp.GetComponent<Renderer>().material.color = new Color32(173, 216, 230, 1);
                    break;
                case 7:
                    gp.GetComponent<Renderer>().material.color = new Color32(128, 0, 128, 1);
                    break;
                case 8:
                    gp.GetComponent<Renderer>().material.color = new Color32(255, 192, 203, 1);
                    break;
                case 9:
                    gp.GetComponent<Renderer>().material.color = new Color32(150, 75, 0, 1);
                    break;
            }
        }
    }
}