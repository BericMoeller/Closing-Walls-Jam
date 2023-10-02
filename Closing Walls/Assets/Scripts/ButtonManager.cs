using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private bool triggerStandard = false;

    public void LevelSelect()
    {
        LevelController.LoadLevel("LevelSelect");
    }

    public void LevelSelecter(string sceneName)
    {
        LevelController.LoadLevel(sceneName);
    }
    
    public void QuitButton()
    {
        LevelController.QuitGame();
    }
    public void BackToMenu()
    {
        LevelController.LoadLevel("MainMenu");
    }
    public void HowToPlay()
    {
        LevelController.LoadLevel("Howtoplay");
    }
    public void Credits()
    {
        LevelController.LoadLevel("Credits");
    }
}
