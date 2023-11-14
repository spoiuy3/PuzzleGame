using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isGrounded; // 플레이어가 땅에 닿아 있는지 확인
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = Vector3.zero;
        isGrounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics.gravity.y < 0f)
        {
            movement = new Vector3(1f, 0f, 0f) * moveSpeed * Time.deltaTime;
        }
        else
        {
            movement = new Vector3(1f, 1f, 0f) * moveSpeed * Time.deltaTime;
        }
        if(!isGrounded)
        {
            movement = Vector3.zero;
        }
        transform.Translate(movement, Space.World);

    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }
}
