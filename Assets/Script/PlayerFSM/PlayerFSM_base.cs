using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM_base : MonoBehaviour
{
    public virtual void enter(newPlayerController body)
    {

    }

    public virtual void loop(newPlayerController body)
    {

    }

    public virtual void leave(newPlayerController body)
    {

    }

    public bool At(float counter,float time)
    {
   
        return counter > time && counter - Time.deltaTime < time;
    }
}
