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
            GameObject.Find("Player").GetComponent<PlayerController>().Death();
        }
    }
    private string ConvertToTime(double val)
    {
        string minutes = ""+(int)(val / 60);
        string seconds = ""+(int)(val % 60);
        if (seconds.Length < 2) seconds = "0" + seconds;
        return minutes + ":" + seconds;
    }
    public double getTimeLeft()
    {
        return TimeToFinish;
    }
}
