using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public GroundUnit myGroundUnit;
    public bool hurt = false;
    public float damage;
    public float time;
    public bool steal;

    public void clear()
    {
        damage = 0;
        time = 0;
        hurt = false;
    }
}
