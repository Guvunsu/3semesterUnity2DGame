using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void startGame()
    {
        try
        {
            SceneManager.LoadScene("Game");
        }
        catch (Exception e)
        {
            Debug.Log("El error fue " + e.Message);
        }

    }
    public void startLevel(string p_sceneName)
    {
        try
        {
            SceneManager.LoadScene(p_sceneName);
        }
        catch (Exception e)
        {
            Debug.Log("El error fue " + e.Message);
        }
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
