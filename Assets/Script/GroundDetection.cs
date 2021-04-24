using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public GroundUnit owner;
    bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        owner.grounded=onGround;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        onGround = true;
    }


}
