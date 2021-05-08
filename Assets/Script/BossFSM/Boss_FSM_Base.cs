using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FSM_Base : MonoBehaviour
{
    public virtual void enter(Boss_controller body)
    {
        body.fist1.transform.localScale = new Vector3(Mathf.Abs(body.fist1.transform.localScale.x) * Mathf.Sign(this.transform.localScale.x), body.fist1.transform.localScale.y, body.fist1.transform.localScale.z);
        body.fist2.transform.localScale = new Vector3(Mathf.Abs(body.fist2.transform.localScale.x) * Mathf.Sign(this.transform.localScale.x), body.fist2.transform.localScale.y, body.fist2.transform.localScale.z);
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
