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
        body.changeState(body.state_attack2);
    }

    public override void leave(Boss_controller body)
    {
        base.leave(body);
    }
}
