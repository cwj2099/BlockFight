using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Vector2 hitforce;
    public bool hit;
    public float damage;
    public float time;

    List<Collider2D> whiteList=new List<Collider2D>();
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!whiteList.Contains(collision))
        {
            hit = true;
            hitforce.x = Mathf.Abs(hitforce.x) * Mathf.Sign(transform.parent.localScale.x);
            whiteList.Add(collision);
            
            if (collision.gameObject.GetComponent<HurtBox>())
            {
                HurtBox hurtBox= collision.gameObject.GetComponent<HurtBox>();
                hurtBox.damage = damage;
                hurtBox.time = time;
                if (hurtBox.myRigidbody2D != null&&!hurtBox.steal)
                {
                    hurtBox.myRigidbody2D.velocity = Vector2.zero;
                    hurtBox.myRigidbody2D.AddForce(hitforce);
                }
                if (hurtBox.myGroundUnit != null)
                {
                    hurtBox.myGroundUnit.GetHurt();
                }
            }
        }
        
    }

    public void deactivate()
    {
        whiteList.Clear();
        gameObject.SetActive(false);
        hit = false;
    }
}
