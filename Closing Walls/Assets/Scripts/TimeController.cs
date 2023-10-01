using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timer;
    public double TimeToFinish;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (TimeToFinish > 0) // if run out of time
        {
            TimeToFinish -= Time.deltaTime;
            timer.text = ConvertToTime(TimeToFinish);
        }
        else
        {
            LevelController.Reset();
        }
    }
    private string ConvertToTime(double val)
    {
        return ""+ (int)(val / 60) + ":" + (int)(val % 60);
    }
    public double getTimeLeft()
    {
        return TimeToFinish;
    }
}
