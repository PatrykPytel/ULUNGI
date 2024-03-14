using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EndofGame : MonoBehaviour
{
    [SerializeField] private Healthmanager Zycie;
    public static bool YouDied = false;
    public GameObject GameOverUI; 
    public GameObject ItemUI;
    [SerializeField] private Openchest skrzynia; 

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Zycie.health==0)
        {
            Pause();
            
        }
        if(skrzynia.opened==true)
       {
            Chestopened();     
       }else {
        Closethechest();
       }

    }
    void Resume()
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        YouDied = false;


    }
    void Pause()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        YouDied = true;

    }
    void Chestopened() {
        ItemUI.SetActive(true);

    } 
    public void Closethechest() { 
        ItemUI.SetActive(false);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        

    }
    
}

