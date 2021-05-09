using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_controller : GroundUnit
{
    public HitBox myHitbox;
    public Animator myAnimator;
    public HurtBox myHurtbox;
    public flashEffect myflashEffect;

    public GameObject fist1;
    public GameObject fist2;

    public Boss_FSM_Base currentState;
    public Boss_FSM_Base state_idle;
    public Boss_FSM_Base state_attack1;
    public Boss_FSM_Base state_attack2;
    public Boss_FSM_Base state_attack3;

    public newPlayerController player;
    public float hp;

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
        player = FindObjectOfType<newPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("end");
        }

        myHitbox.deactivate();
        myHitbox.gameObject.SetActive(true);
        currentState.loop(this);
    }

    public override void GetHurt()
    {
        base.GetHurt();
        hp -= myHurtbox.damage;
        myHurtbox.clear();
        myflashEffect.whiteSprite();
    }
}
