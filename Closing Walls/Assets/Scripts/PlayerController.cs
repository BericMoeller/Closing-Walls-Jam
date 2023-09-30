using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Vector2> dirTouching;
    public List<Vector2> wantsToMove;
    public float speed = 0.05f;
    public float gravitySpeed = 0.2f;
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        dirTouching = new List<Vector2>();
        wantsToMove = new List<Vector2>();
        velocity = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            wantsToMove.Add(new Vector2(0, 1));
        }
        if(Input.GetKey(KeyCode.S))
        {
            wantsToMove.Add(new Vector2 (0, -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            wantsToMove.Add(new Vector2 (1, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            wantsToMove.Add (new Vector2 (-1, 0));
        }
    }

    private void FixedUpdate()
    {
        velocity *= 0.8f;
        Vector2 totalVel = new Vector2(0,0);
        Vector2 collisionDir = new Vector2(0, 0);
        for (int i = 0; i < dirTouching.Count; i++)
        {
            collisionDir.x += dirTouching[i].x;
            collisionDir.y += dirTouching[i].y;
        }
        collisionDir.Normalize();
        for (int i = 0; i < wantsToMove.Count; i++)
        {
            totalVel.x += wantsToMove[i].x;
            totalVel.y += wantsToMove[i].y;
        }
        totalVel.Normalize();
        float dotResult = Vector2.Dot(velocity, collisionDir);
        if (collisionDir.x != 0 || collisionDir.y != 0)
        {
            Debug.Log("totalVel: "+totalVel+". collisionDir: "+collisionDir+". dot: "+dotResult);
        }
        if (dotResult >= 0){
            velocity += totalVel * speed;
        }
        else
        {
            velocity = collisionDir* speed;
        }
        dirTouching.Clear();
        wantsToMove.Clear();
        transform.position += (Vector3)velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal;
        for(int i = 0; i < collision.contactCount; i++)
        {
            normal = collision.contacts[i].normal;
            dirTouching.Add(normal);
            Debug.Log(normal);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
