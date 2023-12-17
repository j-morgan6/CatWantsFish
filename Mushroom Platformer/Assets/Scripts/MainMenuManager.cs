using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //open game scene
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //open how to scene
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowTo");
    }

    //open main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //exit game
    public void ExitGame()
    {
        Application.Quit();
    }
}
