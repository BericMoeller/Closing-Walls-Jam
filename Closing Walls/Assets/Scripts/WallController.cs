using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Wall1;
    public GameObject Wall2;
    public int width;
    public int secondsLeft;
    private double endTime;
    public double startTime;
    private float speedToClose;
    void Start()
    {
        startTime = Time.timeAsDouble + 0;
        speedToClose = (width / 2) / secondsLeft;
        endTime = startTime + secondsLeft;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        secondsLeft = (int)(endTime - Time.timeAsDouble);
        Wall1.transform.position = new Vector3(0 - (speedToClose * secondsLeft), 0, 0);
        Wall2.transform.position = new Vector3(0 + (speedToClose * secondsLeft), 0, 0);
        Debug.Log("LeftWall = "+ (0 - (speedToClose * secondsLeft))+". Right Wall = "+ (0 + (speedToClose * secondsLeft)));
    }
}
