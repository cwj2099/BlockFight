using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack1 : Boss_FSM_Base
{
    public HitBox hitbox;
    public float duration;
    float counter;
    public override void enter(Boss_controller body)
    {
        base.enter(body);
        
        counter = duration;
        body.myAnimator.Play("Boss_attack1");
    }

    public override void loop(Boss_controller body)
    {
        base.loop(body);
        counter -= Time.deltaTime;

        if (At(counter, duration - 0.75f))
        {
            hitbox.gameObject.SetActive(true);
        }

        if(At(counter,duration - 1.25f))
        {
            hitbox.deactivate();
        }

        if (counter <= 0)
        {
            body.changeState(body.state_attack3);
        }
    }

    public override void leave(Boss_controller body)
    {
        base.leave(body);
        hitbox.deactivate();
        body.myAnimator.Play("Boss_idle");
    }
}
