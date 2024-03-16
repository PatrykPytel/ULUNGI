using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject PauseMenuUI;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();

            }

            else
            {
                Pause();

            }

        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Debug.Log("resume");
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("MainMenu");
    }  
    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }
}
