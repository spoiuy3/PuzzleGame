using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{

    public Transform playerTransform;
    public float trackingSpeed = 5f;
    Rigidbody rb;
    public static Vector3 a; 
    public Vector3 b;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.Find("fbKnight").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.gravity.z != 0)
        {
            

            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, trackingSpeed * Time.deltaTime);
            
        }
        else
        {
             transform.position += -a * trackingSpeed * 0.005f;
        }
    }

    
}
