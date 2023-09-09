using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public GameObject gameOverMenu;
    public static bool isOver;

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        isOver = true;
    }

    public void Replay()
    {
        ClearPause();
        SceneManager.LoadScene("ThingOne");
    }

        public void GoToMainMenu()
    {
        ClearPause();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void ClearPause()
    {
        Time.timeScale = 1f;
        isOver = false;
        gameOverMenu.SetActive(false);
    }
}
