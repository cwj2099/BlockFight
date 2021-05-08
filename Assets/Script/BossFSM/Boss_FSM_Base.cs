using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FSM_Base : MonoBehaviour
{
    public virtual void enter(Boss_controller body)
    {

    }

    public virtual void loop(Boss_controller body)
    {

    }

    public virtual void leave(Boss_controller body)
    {

    }

    public bool At(float counter, float time)
    {

        return counter > time && counter - Time.deltaTime < time;
    }
}
