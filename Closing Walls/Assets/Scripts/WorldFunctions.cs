using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WorldFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public float width;
    void Start()
    {
        width = Screen.width + 0f;
    }

    // Update is called once per frame
    void Update()
    {
        width -= 0.01f;
        PlayerSettings.defaultScreenWidth = (int)width;
        EditorPrefs.SetInt("ScreenWidth", (int)width);
    }
}
