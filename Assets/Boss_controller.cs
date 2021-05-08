using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_controller : GroundUnit
{
    public HitBox myHitbox;
    public Animator myAnimator;
    public HurtBox myHurtbox;
    public flashEffect myflashEffect;

    public Boss_FSM_Base currentState;
    public Boss_FSM_Base state_idle;
    public Boss_FSM_Base state_attack1;
    public Boss_FSM_Base state_attack2;
    public Boss_FSM_Base state_attack3;

    public void changeState(Boss_FSM_Base newState)
    {
        currentState.leave(this);
        currentState = newState;
        currentState.enter(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = state_idle;   
    }

    // Update is called once per frame
    void Update()
    {
        myHitbox.deactivate();
        myHitbox.gameObject.SetActive(true);
        currentState.loop(this);
    }

    public override void GetHurt()
    {
        base.GetHurt();
        myflashEffect.whiteSprite();
    }
}
