using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private AudioSource Level_terazniejszosc_gogogo;
    [SerializeField] private AudioSource sonudtrack_menu_gowno;
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
        Level_terazniejszosc_gogogo.Play();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        sonudtrack_menu_gowno.Play();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("MainMenu");
        sonudtrack_menu_gowno.Play();
    }  
    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }
}
