using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombie_controller : Zombie_controller
{
    public float speed;
    public float detection;
    public GameObject upgrade;
    public override void life_circle()
    {
        base.life_circle();
        //tract player when movebale
        if (player != null && Mathf.Abs(player.transform.position.x - transform.position.x) < detection&&stunCounter<=0)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime*Mathf.Sign(transform.transform.localScale.x), 0, 0));
        }
        //reborn to origin if too far from player and player is not closed to origin
        if (player != null && Mathf.Abs(player.transform.position.x - transform.position.x)>30&& Mathf.Abs(player.transform.position.x - origin.x)>30)
        {
            reborn();
        }
    }

    public override void die()
    {
        base.die();
        if (Random.Range(0f, 5f) < 1f)
        {
            Instantiate(upgrade, transform.position+Vector3.up*3, transform.rotation);
        }
    }
}
