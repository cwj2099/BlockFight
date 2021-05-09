using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack3 : Boss_FSM_Base
{
    public HitBox hitbox1;
    public HitBox hitbox2;
    public float duration;
    float counter;
    public override void enter(Boss_controller body)
    {
        base.enter(body);
        counter = duration;
        body.myAnimator.Play("Boss_attack3");
    }

    public override void loop(Boss_controller body)
    {
        base.loop(body);
        counter -= Time.deltaTime;

        if (At(counter, duration - 0.75f))
        {
            hitbox1.gameObject.SetActive(true);
            hitbox2.gameObject.SetActive(true);
        }

        if(At(counter,duration - 1.5f))
        {
            hitbox1.deactivate();
            hitbox2.deactivate();
        }

        if (counter <= 0)
        {
            body.changeState(body.state_idle);
        }
    }

    public override void leave(Boss_controller body)
    {
        base.leave(body);
        hitbox1.deactivate();
        hitbox2.deactivate();
        body.myAnimator.Play("Boss_idle");
    }
}
