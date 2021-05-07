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

    public Rigidbody2D thisRigidbody2D;
    public SpriteRenderer thisSpriteRenderer;
    public Animator thisAnimator;

    public Vector2 velocity;
    public Vector3 iniScale;
    private float jumpCounter;

    public PlayerFSM_base currentState;
    public PlayerFSM_base state_neutral;
    public PlayerFSM_base state_dash;
    public PlayerFSM_base state_attack1;
    public PlayerFSM_base state_attack2;
    public PlayerFSM_base state_attack3;
    public PlayerFSM_base state_attackAir;
    public PlayerFSM_base state_hurt;

    public float energyMax;
    public float energy;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        iniScale = transform.localScale;
        currentState = state_neutral;
        energy = energyMax;
    }

    public void changeState(PlayerFSM_base newState)
    {
        currentState.leave(this);
        currentState = newState;
        currentState.enter(this);
    }
    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
        currentState.loop(this);
        energy = Mathf.Min(energy, energyMax);
        transform.Translate(velocity * Time.deltaTime);
    }

    void movement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : airDeceleration;
        
        

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }
    }

    public void jump()
    {
        //float jumpInput = Input.GetAxisRaw("Jump");
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                thisRigidbody2D.gravityScale = 0;
                jumpCounter = Time.deltaTime;
                velocity.y = jumpHeight / jumpTime ;
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.K)&&energy>=1)
            {
                energy -= 1;
                thisRigidbody2D.velocity = Vector2.zero;
                thisAnimator.Play("player_doubleJump");
                thisRigidbody2D.gravityScale = 0;
                jumpCounter = jumpTime/2;
                velocity.y = jumpHeight / jumpTime;
            }
            if (thisRigidbody2D.gravityScale == 0)
            {
                if (Input.GetKey(KeyCode.K)&&jumpCounter<jumpTime)
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

    public void attempDash()
    {
        if (Input.GetKeyDown(KeyCode.L) && energy >= 1)
        {
            changeState(state_dash);
            energy -= 1;
        }
    }

    public override void GetHurt()
    {
        base.GetHurt();
        changeState(state_hurt);
    }
}
