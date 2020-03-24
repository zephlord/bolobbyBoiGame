using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Controller : MonoBehaviour
{

    public Vector2 velocity;
    public Vector2 maxVelocity = new Vector2(10,10);
    public float acceleration;
    public float deceleration;
    public float force;
    public Rigidbody2D player;
    // Start is called before the first frame update
    
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentVel = player.velocity;
        float currentYVel = currentVel.y;
        float currentXVel = currentVel.x;
        if(Input.GetKey(KeyCode.W)) {
            //currentYVel = Mathf.Min(maxVelocity.y, currentYVel + (Time.deltaTime * acceleration));
            //currentVel.y = currentYVel;
            player.AddForce(Vector2.up * force);

        }

        else if(Input.GetKey(KeyCode.S)) {
            // currentYVel = Mathf.Max(-maxVelocity.y, currentYVel - (Time.deltaTime * acceleration));
            // currentVel.y = currentYVel;
            player.AddForce(Vector2.down * force);
        }

        // else {
        //     if(player.velocity.y > 0)
        //     {
        //         currentYVel = Mathf.Max(0, currentYVel - (Time.deltaTime * deceleration));
        //         currentVel.y = currentYVel;
        //     }
        //     else if(player.velocity.y < 0)
        //     {
        //         currentYVel = Mathf.Min(0, currentYVel + (Time.deltaTime * deceleration));
        //         currentVel.y = currentYVel;
        //     }
        // }


        if(Input.GetKey(KeyCode.D)) {
            // currentXVel = Mathf.Min(maxVelocity.x, currentXVel + (Time.deltaTime * acceleration));
            // currentVel.x = currentXVel;
            player.AddForce(Vector2.right * force); 
        }

        else if(Input.GetKey(KeyCode.A)) {
            // currentXVel = Mathf.Max(-maxVelocity.x, currentXVel - (Time.deltaTime * acceleration));
            // currentVel.x = currentXVel;
            player.AddForce(Vector2.left * force);
        }

        // else {
        //     if(player.velocity.x > 0)
        //     {
        //         currentXVel = Mathf.Max(0, currentXVel - (Time.deltaTime * deceleration));
        //         currentVel.x = currentXVel;
        //     }
        //     else if(player.velocity.x < 0)
        //     {
        //         currentXVel = Mathf.Min(0, currentXVel + (Time.deltaTime * deceleration));
        //         currentVel.x = currentXVel;
        //     }
        // }

        //player.velocity = currentVel;
    }
}
