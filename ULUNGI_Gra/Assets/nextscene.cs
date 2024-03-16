using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
