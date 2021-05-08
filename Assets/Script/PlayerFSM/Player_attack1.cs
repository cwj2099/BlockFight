using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack1 : PlayerFSM_base
{
    public HitBox hitbox;
    public float duration;
    float counter;
    public override void enter(newPlayerController body)
    {
        base.enter(body);
        counter = duration;
        body.thisAnimator.Play("player_attack1");
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);
        //stop player from moving
        body.velocity = Vector2.zero;
        //I added this movement to avoid a very weird bug: if player and the enemy is not moving at all, sometimes the collision just do not happend
        if (counter>duration-0.6f)
        {
            body.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * 1, 0);
        }
        //if arrive this moment, do something form
        if (At(counter,duration-0.12f))
        {
            hitbox.gameObject.SetActive(true);
        }

        if (At(counter, duration-0.22f))
        {
            hitbox.deactivate();
        }


        counter -= Time.deltaTime;

        if (counter <= duration - 0.22f)
        {
            if (Input.GetKey(KeyCode.J)) { body.changeState(body.state_attack2); }    
        }

        //return to neutral if time up or jump cancel
        if (counter <= 0|| Input.GetAxisRaw("Jump")==1)
        {
            body.changeState(body.state_neutral);
            body.jump();
        }
        body.attempDash();
        if (hitbox.hit)
        {
            hitbox.hit = false;
            body.energy += 0.5f;
        }
    }

    public override void leave(newPlayerController body)
    {
        base.leave(body);
        hitbox.deactivate();
        body.thisAnimator.Play("player_idle");
    }
}
