using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack2 : Boss_FSM_Base
{
    public HitBox hitbox1;
    public HitBox hitbox2;
    public float duration;
    float counter;
    public override void enter(Boss_controller body)
    {
        base.enter(body);
        counter = duration;
        body.fist1.transform.localScale = new Vector3(body.fist1.transform.localScale.x*-1 , body.fist1.transform.localScale.y, body.fist1.transform.localScale.z);
        body.myAnimator.Play("Boss_attack2");
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

        if(At(counter,duration - 1.25f))
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
