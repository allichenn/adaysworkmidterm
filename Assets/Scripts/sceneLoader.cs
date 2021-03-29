using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    public GameObject startScreen, instructionScreen;

    void Start()
    {
        instructionScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void loadGame(){
        SceneManager.LoadScene("levelOne");
    }

    public void goBack(){
        //SceneManager.LoadScene("menu");
        startScreen.SetActive(true);
        instructionScreen.SetActive(false);
    }

    public void goInstructions(){
        //SceneManager.LoadScene("instructions");
        startScreen.SetActive(false);
        instructionScreen.SetActive(true);
    }

    public void restart(){
       SceneManager.LoadScene("menu");
    }
}
