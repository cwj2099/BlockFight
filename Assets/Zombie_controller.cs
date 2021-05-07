using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_controller : GroundUnit
{
    public HitBox myHitbox;
    public Animator myAnimator;
    public HurtBox myHurtbox;
    [SerializeField]
    float stunCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myHitbox.deactivate();
        myHitbox.gameObject.SetActive(true);
        if (stunCounter > 0)
        {
            stunCounter -= Time.deltaTime;
            myHitbox.deactivate();
        }
        else
        {
            if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie_idle"))
            {
                myAnimator.Play("zombie_idle");
            }
        }
        
    }

    public override void GetHurt()
    {
        base.GetHurt();
        stunCounter = myHurtbox.time;
        myHurtbox.clear();
        //myAnimator.Play("zombie_hurt1");
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie_hurt1"))
        {
            myAnimator.Play("zombie_hurt2");
        }
        else
        {
            myAnimator.Play("zombie_hurt1");
        }
    }
}
