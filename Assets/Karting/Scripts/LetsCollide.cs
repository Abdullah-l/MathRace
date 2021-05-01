using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using TMPro;

namespace KartGame.KartSystems
{
    public class LetsCollide : MonoBehaviour
    {

        public TextMeshProUGUI equation;
        public InputField answer;
        public GameObject kart;

        public Text correctAnswer;

        private int result;

        private KartMovement km;
        private KartAnimation ka;

        public Text cubes;
        public Text wrongs;

        private CubeCounter cs;

        public GameObject EOLcanvas;

        GameObject timer;

        TMP_InputField studentName;


        // string quesToDb = "";

        // string statToDb = "";
        void Start()
        {
            cs = kart.GetComponent<CubeCounter>();
            wrongs = GameObject.Find("Incorrect Counter").GetComponent<Text>();
        }

        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Player")
            {
                answer.characterLimit = 2;
                equation.gameObject.SetActive(true);
                answer.gameObject.SetActive(true);
                answer.ActivateInputField();
                Destroy(GetComponent<BoxCollider>());
                Destroy(GetComponent<MeshRenderer>());
                km = kart.GetComponent<KartMovement>();
                ka = kart.GetComponent<KartAnimation>();
                km.enabled = !km.enabled;
                ka.enabled = !ka.enabled;
                //quesToDb = equation.text;
                answer.onEndEdit.AddListener(delegate { Submited(); });
            }
        }

        private void Submited()
        {
            result = int.Parse(answer.text);
            // if (quesToDb != equation.text){
            //     quesToDb = equation.text;
            //     statToDb += equation.text + " ";
            //     statToDb += answer.text + ", ";
            // }
            // else {
            //     statToDb +=  answer.text + ", ";
            // }            
            if (result == int.Parse(correctAnswer.text))
            {
                equation.gameObject.SetActive(false);
                answer.gameObject.SetActive(false);
                km.enabled = !km.enabled;
                ka.enabled = !ka.enabled;
                cubes.text = "Cubes left: " + cs.i + "/" + cs.iDefault;
                if (cs.i == 0)
                {
                    km.enabled = false;
                    ka.enabled = false;
                    //EOLcanvas = GameObject.Find("EndOfLevel");
                    EOLcanvas.SetActive(true);
                    timer = GameObject.Find("Time");
                    timer.SetActive(false);
                }
            }
            else
            {
                cs.wrongCounter++;
                wrongs.text = "Incorrect answers: " + cs.wrongCounter;
                answer.placeholder.GetComponent<Text>().text = "Try Again";
                answer.text = "";
                answer.ActivateInputField();
            }

        }
    }

}