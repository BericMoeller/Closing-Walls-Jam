using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        for(int i = 0; i < collision.contactCount; i++)
        {
            ContactPoint2D contactPoint = collision.contacts[i];
        }

        
    }
}
