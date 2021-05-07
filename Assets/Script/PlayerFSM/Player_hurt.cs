using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hurt: PlayerFSM_base
{
    public BoxCollider2D myHurtBox;
    public float duration;
    float counter;
    public override void enter(newPlayerController body)
    {
        base.enter(body);
        counter = duration;
        myHurtBox.gameObject.SetActive(false);
        body.thisAnimator.Play("player_hurt");
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);
        //stop player from moving
        body.velocity = Vector2.zero;
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            body.changeState(body.state_neutral);
        }

    }

    public override void leave(newPlayerController body)
    {
        base.leave(body);
        body.thisRigidbody2D.velocity = Vector2.zero;
        body.thisAnimator.Play("player_idle");
        myHurtBox.gameObject.SetActive(true);
    }
}
