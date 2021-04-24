//partially stolen from "https://github.com/IronWarrior/2DCharacterControllerTutorial/blob/master/Assets/Scripts/CharacterController2D.cs"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerController : GroundUnit
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Deceleration applied when character is air and not attempting to move.")]
    float airDeceleration = 30;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    [SerializeField, Tooltip("Time cost of jumping to the max height")]
    float jumpTime = 0.5f;

    [SerializeField, Tooltip("the remaining force after jump end")]
    float jumpDrag = 10f;

    [SerializeField, Tooltip("gravityscale")]
    float gravityfallScale = 9f;

    [SerializeField, Tooltip("Time before reaching max gravity scale")]
    float gravityTime= 0.5f;

    private Rigidbody2D thisRigidbody2D;

    private Vector2 velocity;
    private float jumpCounter;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    void movement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : airDeceleration;
        
        jump();

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }
        transform.Translate(velocity * Time.deltaTime);
    }

    void jump()
    {
        float jumpInput = Input.GetAxisRaw("Jump");
        if (grounded)
        {
            if (jumpInput == 1)
            {
                thisRigidbody2D.gravityScale = 0;
                jumpCounter = Time.deltaTime;
                velocity.y = jumpHeight / jumpTime ;
            }
        }
        else {
            if (thisRigidbody2D.gravityScale == 0)
            {
                if (jumpInput == 1&&jumpCounter<jumpTime)
                {
                    velocity.y = jumpHeight / jumpTime;
                    jumpCounter += Time.deltaTime;
                }
                else
                {
                    thisRigidbody2D.gravityScale = gravityfallScale/gravityTime *Time.deltaTime;
                    thisRigidbody2D.AddForce(Vector2.up*thisRigidbody2D.mass*jumpDrag);
                }
            }
            else
            {
                velocity.y = 0;
                thisRigidbody2D.gravityScale = Mathf.Min(gravityfallScale, thisRigidbody2D.gravityScale + gravityfallScale / gravityTime * Time.deltaTime);
            }

        }

    }
}
