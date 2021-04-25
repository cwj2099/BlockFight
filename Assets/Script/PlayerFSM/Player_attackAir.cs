using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attackAir : PlayerFSM_base
{
    public HitBox hitbox;
    public float duration;
    float counter;
    public override void enter(newPlayerController body)
    {
        base.enter(body);
        counter = duration;
        body.thisAnimator.Play("player_attackAir");
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);

        if (At(counter, 0.4f)){hitbox.gameObject.SetActive(true);}
        if (At(counter, 0.35f)) { hitbox.deactivate(); }
        if (At(counter, 0.3f)) { hitbox.gameObject.SetActive(true); }
        if (At(counter, 0.25f)) { hitbox.deactivate(); }
        if (At(counter, 0.2f)) { hitbox.gameObject.SetActive(true); }
        if (At(counter, 0.15f)) { hitbox.deactivate(); }

        counter -= Time.deltaTime;
        //return to neutral if time up or land on ground
        if (counter <= 0 || body.grounded)
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
