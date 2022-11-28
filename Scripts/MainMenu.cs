using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level01");
    }
    public void Level_One()
    {
        SceneManager.LoadScene("Level01");
    }
    public void Level_Two()
    {
        SceneManager.LoadScene("Level02");
    }
    public void Level_Three()
    {
        SceneManager.LoadScene("Level03");
    }
    public void StartScreen()
    {
        SceneManager.LoadScene("StartingScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
