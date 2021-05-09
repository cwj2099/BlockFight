using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_idle : Boss_FSM_Base
{
    public override void enter(Boss_controller body)
    {
        base.enter(body);
    }

    public override void loop(Boss_controller body)
    {
        base.loop(body);
        //rotate according to player
        if (body.player != null && body.player.gameObject.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if ( body.player!=null&&Mathf.Abs(body.player.gameObject.transform.position.x - transform.position.x) > 10)
        {
            body.changeState(body.state_attack3);
        }
        else
        {
            float num = Random.Range(0, 2);
            if (num < 1)
            {
                body.changeState(body.state_attack1);
            }
            else 
            {
                body.changeState(body.state_attack2);
            }

            
        }
        
    }

    public override void leave(Boss_controller body)
    {
        base.leave(body);
    }
}
