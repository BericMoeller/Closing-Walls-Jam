using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    private Vector3 growthy;
    private Vector3 moveleft;
    private Vector3 moveright;
    private bool hasEnded = false;
    private float multiplier;
    public GameObject worldObject;

    [SerializeField]
    private Transform left;
    
    [SerializeField]
    private Transform right;
    
    [SerializeField]
    private Transform top;

    [SerializeField]
    private Transform bottom;


    // Start is called before the first frame update
    void Start()
    {
        multiplier = 0.38f/((float)(worldObject.GetComponent<TimeController>().getTimeLeft()));

        growthy = new Vector3(0f, 1f, 0f) * multiplier;
        moveleft = new Vector3(-1f, 0f, 0f) * multiplier;
        moveright = new Vector3(1f, 0f, 0f) * multiplier;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!hasEnded)
        {
            bottom.localScale += growthy;
            top.localScale += growthy;
            left.localPosition += moveright;
            right.localPosition += moveleft;
        }
    }
    public void End()
    {
        hasEnded = true;
    }

}
