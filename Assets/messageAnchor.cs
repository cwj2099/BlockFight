using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class messageAnchor : MonoBehaviour
{
    public string content;
    GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("Text");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<newPlayerController>())
        {
            container.GetComponent<Text>().text = content;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<newPlayerController>())
        {
            container.GetComponent<Text>().text = "";
        }
    }

}
