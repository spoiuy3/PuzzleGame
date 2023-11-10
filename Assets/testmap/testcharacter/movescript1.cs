using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript1 : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절
    public float jumpForce = 10f; // 점프 힘 조절
    private bool isGrounded; // 플레이어가 땅에 닿아 있는지 확인

    void Update()
    {
        // 키 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        

        // 이동 벡터 계산
        Vector3 movement = new Vector3(-1f* horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // 이동 적용
        transform.Translate(movement, Space.World);

        // 점프 처리
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (movement != Vector3.zero)
        {
            transform.LookAt(transform.position + movement);
        }
    }
    void Jump()
    {
        // 플레이어에게 y 방향으로 힘을 주어 점프
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // 점프 후에는 땅에 닿아있지 않음
    }

    void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿아 있는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}