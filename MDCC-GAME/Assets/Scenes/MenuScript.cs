using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainArea");
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}

