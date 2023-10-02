using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject BlackBorders;
    public GameObject borders;
    private AudioSource winSound;
    // Start is called before the first frame update
    void Start()
    {
        winSound = GetComponent<AudioSource>();
        BlackBorders.transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winSound.Play();
        Destroy(collision.gameObject);
        borders.GetComponent<BorderScript>().End();
        coroutine = WaitForWalls();
        StartCoroutine(coroutine);
        
    }
    private IEnumerator WaitForWalls()
    {
        Vector3 initScale = BlackBorders.transform.localScale;

        for(int i = 100; i > 0; i--)
        {
            BlackBorders.transform.localScale = (initScale / 100)*i;
            yield return new WaitForSeconds(0.015f);
        }
        LevelController.LoadLevel("LevelSelect");
    }
}
