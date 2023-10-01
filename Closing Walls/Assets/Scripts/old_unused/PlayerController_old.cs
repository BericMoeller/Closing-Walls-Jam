using System.Collections.Generic;
using UnityEngine;

public class PlayerController_old : MonoBehaviour
{
    public List<Vector2> dirTouching;
    public List<Vector2> wantsToMove;
    public float speed = 0.05f;
    private float gravitySpeed = 0.003f;
    public Vector2 velocity;
    public bool touchingGround = false;
    public int jumpLeft = 0;
    public bool canJump;
    public int fallingFor = 0;
    public float stuck = 0.0f;
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
        if(Input.GetKey(KeyCode.W) && jumpLeft > 0&&canJump)
        {
            wantsToMove.Add(new Vector2(0, 1));
            jumpLeft--;
        }
        else
        {
            canJump = false;
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
        touchingGround = false;
        bool hasUpwardsThrust = false;
        velocity *= 0.8f;
        Vector2 totalVel = new Vector2(0, 0);
        Vector2 collisionDir = new Vector2(0, 0);
        for (int i = 0; i < dirTouching.Count; i++)
        {
            collisionDir.x += dirTouching[i].x;
            collisionDir.y += dirTouching[i].y;
        }
        collisionDir.Normalize();
        for (int i = 0; i < wantsToMove.Count; i++)
        {
            if (wantsToMove[i].Equals(Vector2.up))
            {
                hasUpwardsThrust = true;
            }
            totalVel.x += wantsToMove[i].x;
            totalVel.y += wantsToMove[i].y;
        }
        totalVel.Normalize();
        float dotResult = Vector2.Dot(velocity, collisionDir);
        if (!collisionDir.Equals(Vector2.zero) && jumpLeft < 100)
        {
            jumpLeft += 5;
            canJump = true;
            Debug.Log("totalVel: "+totalVel+". collisionDir: "+collisionDir+". dot: "+dotResult);
        }
        if (dotResult >= 0) {
            velocity += totalVel * speed;
        }
        else
        {
            velocity = collisionDir * speed;
        }
        if (Vector2.Dot(collisionDir, Vector2.down) < 0)
        {
            touchingGround = true;
            if (jumpLeft > 70)
            {
                velocity.y = 0;
            }
            jumpLeft = 80;
            canJump = true;
            if (stuck < 0.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - stuck, transform.position.z);
                velocity.y = 0;
            }
        }
        else
        {
            stuck = 0.0f;
        }
        dirTouching.Clear();
        wantsToMove.Clear();
        if(!touchingGround && !hasUpwardsThrust)
        {
            fallingFor++;
            velocity.y -= gravitySpeed * fallingFor;
        }
        else
        {
            fallingFor = 0;
        }
        transform.position += (Vector3)velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionBehavior(collision);
    }
    private void CollisionBehavior(Collision2D collision){
        Vector2 normal;
        for (int i = 0; i < collision.contactCount; i++)
        {
            normal = collision.contacts[i].normal;
            if (collision.contacts[i].separation < -0.1f)
            {
                stuck = collision.contacts[i].separation;
            }
            dirTouching.Add(normal);
            Debug.Log(normal);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionBehavior(collision);
    }
}
