using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_neutral : PlayerFSM_base
{
    public override void enter(newPlayerController body)
    {
        base.enter(body);
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);
        //float dashInput = Input.GetAxisRaw("Fire3");
        //float attackInput = Input.GetAxisRaw("Fire1");

        //change facing accoridngly
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            body.transform.localScale = new Vector3(body.iniScale.x * Input.GetAxisRaw("Horizontal"), body.iniScale.y, body.iniScale.z);
        }
        


        if (Input.GetKeyDown(KeyCode.L))
        {
            body.changeState(body.state_dash);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (body.grounded)
            {
                body.changeState(body.state_attack1);
            }
            else
            {
                body.changeState(body.state_attackAir);
            }
            
        }
    }

    public override void leave(newPlayerController body)
    {
        base.leave(body);
    }
}
