using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Instruct : MonoBehaviour
{
    public void backBtn(){
        SceneManager.LoadScene("Main menu");
    }
        public void level1Btn(){
        SceneManager.LoadScene("Level 1");
    }
        public void level2Btn(){
        SceneManager.LoadScene("Level 2");
    }
        public void level3Btn(){
        SceneManager.LoadScene("Level 3");
    }
        public void level4Btn(){
        SceneManager.LoadScene("Level 4");
    }
        public void level5Btn(){
        SceneManager.LoadScene("Level 5");
    }
    
}
