using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<newPlayerController>())
        {
            collision.gameObject.GetComponent<newPlayerController>().hp++;
            Destroy(gameObject);
        }
    }
}
