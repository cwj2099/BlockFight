using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Vector2 hitforce;
    public bool hit;

    List<Collider2D> whiteList=new List<Collider2D>();
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!whiteList.Contains(collision))
        {
            hit = true;
            hitforce.x = Mathf.Abs(hitforce.x) * Mathf.Sign(transform.parent.localScale.x);
            whiteList.Add(collision);
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.attachedRigidbody.AddForce(hitforce);
        }
        
    }

    public void deactivate()
    {
        whiteList.Clear();
        gameObject.SetActive(false);
        hit = false;
    }
}
