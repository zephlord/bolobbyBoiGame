using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Controller : MonoBehaviour
{

    public Vector2 velocity;
    public Vector2 maxVelocity = new Vector2(1,1);
    public float acceleration;
    public Rigidbody2D player;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) {
            Vector2 currentVel = player.velocity;
            float currentYVel = currentVel.y;
            currentYVel = Mathf.Min(maxVelocity.y, currentYVel + (Time.deltaTime * acceleration));
            currentVel.y = currentYVel;
            player.velocity = currentVel;
        }

        if(Input.GetKey(KeyCode.S)) {
            Vector2 currentVel = player.velocity;
            float currentYVel = currentVel.y;
            currentYVel = Mathf.Max(-maxVelocity.y, currentYVel - (Time.deltaTime * acceleration));
            currentVel.y = currentYVel;
            player.velocity = currentVel;
        }

        if(Input.GetKey(KeyCode.D)) {
            Vector2 currentVel = player.velocity;
            float currentXVel = currentVel.x;
            currentXVel = Mathf.Min(maxVelocity.x, currentXVel + (Time.deltaTime * acceleration));
            currentVel.x = currentXVel;
            player.velocity = currentVel;
        }

        if(Input.GetKey(KeyCode.A)) {
            Vector2 currentVel = player.velocity;
            float currentXVel = currentVel.x;
            currentXVel = Mathf.Max(-maxVelocity.x, currentXVel - (Time.deltaTime * acceleration));
            currentVel.x = currentXVel;
            player.velocity = currentVel;
        }
    }
}
