using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSideController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool FacingLeft = false;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().flipX = FacingLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Boost");
        other.GetComponent<PlayerController>().BoostSide(25f,FacingLeft);
        Destroy(gameObject);
    }

}
