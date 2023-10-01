using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static void LoadLevel(string level)
    {
        Debug.Log("Attempting to load " + level);
        SceneManager.LoadScene(level);
    }
    public static void QuitGame()
    {
        Debug.Log("Attempting to quit...");
        Application.Quit();
    }
    public static void WinGame(string winner)
    {
        LoadLevel("Menu");
    }
    public static void Reset()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }
}
