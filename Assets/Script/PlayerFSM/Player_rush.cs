using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_rush : PlayerFSM_base
{
    public HitBox hitbox;
    public LayerMask toDetec;
    public Vector2 detectionSize;
    public float keepDistance;
    //public float detectionDistance;
    public float maxDistance;
    public float dashDuration;
    public float duration;

    float travelDistance;
    float counter;
    bool attack;
    public override void enter(newPlayerController body)
    {
        base.enter(body);
        attack = false;
        body.thisAnimator.Play("player_dash");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            body.transform.localScale = new Vector3(body.iniScale.x * Input.GetAxisRaw("Horizontal"), body.iniScale.y, body.iniScale.z);
        }
        body.thisRigidbody2D.velocity = Vector3.zero;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, detectionSize, 0,  new Vector2(Mathf.Sign(body.transform.localScale.x),0), maxDistance+detectionSize.x,toDetec);
        if (!hit)
        {
            travelDistance = maxDistance;
        }
        else
        {
            attack = true;
            travelDistance = Mathf.Abs(hit.distance-keepDistance);
        }
        
        counter = duration;
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);
        if (attack) { body.thisRigidbody2D.velocity = Vector3.zero; }
        body.velocity = new Vector2(travelDistance*Mathf.Sign(transform.localScale.x) / dashDuration, 0);
        
        if (At(counter, duration - dashDuration))
        {
            if (attack) { hitbox.gameObject.SetActive(true);  }
            else { counter -= 0.25f; }
            
        }

        if (counter<(duration-dashDuration))
        {
            body.velocity = Vector2.zero;
        }

        counter -= Time.deltaTime;

        if (counter <= 0 || (Input.GetAxisRaw("Jump") == 1&&body.grounded))
        {
            body.changeState(body.state_neutral);
        }
    }

    public override void leave(newPlayerController body)
    {
        base.leave(body);
        body.velocity = Vector2.zero;
        hitbox.deactivate();
    }
}
