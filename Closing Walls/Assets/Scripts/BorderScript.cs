using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    private Vector3 growthy;
    private Vector3 moveleft;
    private Vector3 moveright;

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
        growthy = new Vector3(0f, 0.01f, 0f);
        moveleft = new Vector3(-0.01f, 0f, 0f);
        moveright = new Vector3(0.01f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        bottom.localScale += growthy;
        top.localScale += growthy;
        left.localPosition += moveright;
        right.localPosition += moveleft;
    }
}
