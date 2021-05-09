using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<newPlayerController>())
        {
            collision.gameObject.GetComponent<newPlayerController>().energyMax++;
            collision.gameObject.GetComponent<newPlayerController>().energy++;
            Destroy(gameObject);
        }
    }
}
