using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WorldFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCamera;
    private Camera cameraObject;
    public GameObject playerObject;
    void Start()
    {
        cameraObject = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       mainCamera.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -10f);
    }
}
