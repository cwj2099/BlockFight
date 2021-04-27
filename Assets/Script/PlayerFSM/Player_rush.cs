using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_rush : PlayerFSM_base
{
    public HitBox hitbox;
    public HitBox hitbox2;
    public HitBox hitbox3;
    public HitBox hitbox3_5;
    public LayerMask toDetec;
    public Vector2 detectionSize;
    public float keepDistance;
    //public float detectionDistance;
    public float maxDistance;
    public float dashDuration;
    public float endDuration;
    public float attackDuration;

    float travelDistance;
    float counter;
    bool attack;
    int Sp=0;
    public override void enter(newPlayerController body)
    {
        base.enter(body);
        attack = false;
        body.thisAnimator.Play("player_dash");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            body.transform.localScale = new Vector3(body.iniScale.x * Input.GetAxisRaw("Horizontal"), body.iniScale.y, body.iniScale.z);
        }
        body.thisRigidbody2D.velocity = Vector3.zero;
        attack = false;
        counter = dashDuration+endDuration;
        travelDistance = maxDistance;
        hitbox.gameObject.SetActive(true);
        //old codes, use raycast to determine attacking or not
        /*RaycastHit2D hit = Physics2D.BoxCast(transform.position, detectionSize, 0,  new Vector2(Mathf.Sign(body.transform.localScale.x),0), maxDistance+detectionSize.x,toDetec);
        if (!hit)
        {
            travelDistance = maxDistance;
        }
        else
        {
            attack = true;
            travelDistance = Mathf.Abs(hit.distance-keepDistance);
        }*/
    }

    public override void loop(newPlayerController body)
    {
        base.loop(body);
        body.thisRigidbody2D.velocity = Vector3.zero;
        //if normal
        if (!hitbox.hit)
        {
            
            if (counter > endDuration)
            {
               body.velocity = new Vector2(travelDistance * Mathf.Sign(transform.localScale.x) / dashDuration, 0);
            }
            else
            {
                body.velocity = Vector2.zero;
            }
        }
        else
        {
            if (!attack)
            {
                attack = true;
                counter += attackDuration;
                Sp++;
                if (Sp == 3) { Sp = 1; }
                 

            }
            else
            {

                //if (counter < attackDuration && counter > attackDuration - 0.16f)
                //auto push back
                if (counter > attackDuration)
                {
                    body.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * -7, 0);
                }
                else
                {
                    body.velocity = Vector2.zero;
                }
                if (Sp == 1)
                {
                    if (At(counter, attackDuration)) { body.thisAnimator.Play("player_sp1"); }
                    if (At(counter, attackDuration - 0.1f)) { hitbox2.gameObject.SetActive(true); }
                }
                else if (Sp == 2)
                {
                    if (At(counter, attackDuration)) { body.thisAnimator.Play("player_sp2"); }
                    if (At(counter, attackDuration - 0.1f)) { hitbox3.gameObject.SetActive(true); }
                    if (At(counter, attackDuration - 0.13f)) { hitbox3.deactivate();hitbox3_5.gameObject.SetActive(true); }
                    if (At(counter, attackDuration - 0.16f)) { hitbox3_5.deactivate(); hitbox3.gameObject.SetActive(true); }
                    if (At(counter, attackDuration - 0.19f)) { hitbox3.deactivate(); hitbox3_5.gameObject.SetActive(true); }
                }


                if (counter < attackDuration - 0.22f)
                {
                    if(Input.GetKeyDown(KeyCode.L) )
                    {
                        body.changeState(body.state_dash);
                    }

                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        
                        body.changeState(body.state_attack1);
                    }
                }
            }


            

        }


        counter -= Time.deltaTime;

        if (counter <= 0 || (Input.GetAxisRaw("Jump") == 1&&body.grounded))
        {
            Sp = 0;
            body.changeState(body.state_neutral);
            body.jump();
        }
    }

    public override void leave(newPlayerController body)
    {
        base.leave(body);
        body.velocity = Vector2.zero;
        hitbox.deactivate();
        hitbox2.deactivate();
        hitbox3.deactivate();
        hitbox3_5.deactivate();
        body.thisAnimator.Play("player_idle");
        //Sp = 0;
    }
}
