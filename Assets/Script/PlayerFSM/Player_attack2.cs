using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack2 : PlayerFSM_base
{
    public HitBox hitbox;
    public float duration;
    float counter;
    public override void enter(newPlayerController body)
    {
        base.enter(body);
        counter = duration;
        body.thisAnimator.Play("player_attack2");
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);
        //stop player from moving
        body.velocity = Vector2.zero;

        //if arrive this moment, do something form
        if (At(counter, duration - 0.12f))
        {
            hitbox.gameObject.SetActive(true);
        }

        if (At(counter, duration - 0.22f))
        {
            hitbox.deactivate();
        }


        counter -= Time.deltaTime;

        if (counter <= duration - 0.22f)
        {
            if (Input.GetKey(KeyCode.J)) { body.changeState(body.state_attack3); }
        }

        //return to neutral if time up or jump cancel
        if (counter <= 0 || Input.GetAxisRaw("Jump") == 1)
        {
            body.changeState(body.state_neutral);
        }

        if (Input.GetAxisRaw("Fire3") == 1)
        {
            body.changeState(body.state_dash);
        }
    }

    public override void leave(newPlayerController body)
    {
        base.leave(body);
        hitbox.deactivate();
        body.thisAnimator.Play("player_idle");
    }
}
