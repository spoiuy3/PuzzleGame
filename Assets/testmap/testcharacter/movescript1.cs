using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript1 : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float jumpForce = 10f; // ���� �� ����
    private bool isGrounded; // �÷��̾ ���� ��� �ִ��� Ȯ��

    void Update()
    {
        // Ű �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        

        // �̵� ���� ���
        Vector3 movement = new Vector3(-1f* horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // �̵� ����
        transform.Translate(movement, Space.World);

        // ���� ó��
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
        // �÷��̾�� y �������� ���� �־� ����
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // ���� �Ŀ��� ���� ������� ����
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���� ��� �ִ��� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}