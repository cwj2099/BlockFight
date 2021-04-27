using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject traction;
    public float tracSpeed = 5f;
    float dx = 0;
    float dy = 0;
    // Start is called before the first frame update
    void Start()
    {
        dx = traction.transform.position.x - transform.position.x;
        dy = traction.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, traction.transform.position.x - dx, tracSpeed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, traction.transform.position.y - dy, tracSpeed * Time.deltaTime),
            transform.position.z);
    }

}
