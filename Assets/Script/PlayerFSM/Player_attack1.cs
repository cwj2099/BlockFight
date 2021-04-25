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

        //if arrive this moment, do something form
        if (At(counter,0.2f))
        {
            hitbox.gameObject.SetActive(true);
        }

        if (At(counter, 0.1f))
        {
            hitbox.deactivate();
        }

        counter -= Time.deltaTime;

        //return to neutral if time up or jump cancel
        if (counter <= 0|| Input.GetAxisRaw("Jump")==1)
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
    }
}
