using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{

    public Transform playerTransform;
    public float trackingSpeed = 5f;
    Rigidbody rb;
    public static Vector3 a; 

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
            if (playerTransform.position.x - transform.position.x < 0f)
            {
                Vector3 desiredRotation = new Vector3(0, 0, 0);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
            else
            {
                Vector3 desiredRotation = new Vector3(0, 180, 0);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
        }
        else
        {
            transform.position += a * trackingSpeed  *Time.deltaTime;
            if (a.x < 0f)
            {
                Vector3 desiredRotation = new Vector3(0, 0, 0);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
            else
            {
                Vector3 desiredRotation = new Vector3(0, 180, 0);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
        }
    }

    
}
