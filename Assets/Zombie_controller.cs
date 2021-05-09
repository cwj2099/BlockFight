using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_controller : GroundUnit
{
    public float maxhp;
    public float hp;
    public HitBox myHitbox;
    public Animator myAnimator;
    public HurtBox myHurtbox;
    public flashEffect myflashEffect;
    public newPlayerController player;
    [SerializeField]
    float stunCounter;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<newPlayerController>();
        hp = maxhp;
        origin = transform.position;
        myAnimator.keepAnimatorControllerStateOnDisable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            die();
            if (player != null && Mathf.Abs(player.gameObject.transform.position.x - origin.x) > 30)
            {
                reborn();
            }
        }
        else
        {
            life_circle();
        }
        
    }

    public override void GetHurt()
    {
        base.GetHurt();
        stunCounter = myHurtbox.time;
        hp -= myHurtbox.damage;
        myHurtbox.clear();
        myflashEffect.whiteSprite();
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

    void die()
    {
        myAnimator.Play("zombie_idle");
        myHitbox.gameObject.SetActive(false);
        myHurtbox.gameObject.SetActive(false);
        myAnimator.gameObject.SetActive(false);
    }

    void reborn()
    {
        hp = maxhp;
        transform.position = origin;
        stunCounter = 0;
        myHitbox.gameObject.SetActive(true);
        myHurtbox.gameObject.SetActive(true);
        myAnimator.gameObject.SetActive(true);
    }

    void life_circle()
    {
        if (player != null && player.gameObject.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
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
}
