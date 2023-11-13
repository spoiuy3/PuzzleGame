using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movescript1 : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float jumpForce = 10f; // ���� �� ����
    private bool isGrounded; // �÷��̾ ���� ��� �ִ��� Ȯ��
    string level;
    public bool haveKey;

    void Start()
    {
        level = SceneManager.GetActiveScene().name;
        haveKey = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && Physics.gravity.y < 0f)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {

        // Ű �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement;

        // �̵� ���� ���
        if (Physics.gravity.y<0f)
        {
            movement = new Vector3(1.5f * horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        }
        else
        {
            movement = new Vector3(1.5f* horizontalInput, 1.5f*verticalInput,0f ) * moveSpeed * Time.deltaTime;
        }


        // �̵� ����
        transform.Translate(movement, Space.World);

        // ���� ó��
        
        if (Physics.gravity.y < 0f)
        {
            if (movement.x < 0f)
            {
                Vector3 desiredRotation = new Vector3(0, -90, 0);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
            else if(movement.x > 0f)
            {
                Vector3 desiredRotation = new Vector3(0, 90, 0);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
        }
        else
        {
            if (movement.x < 0f)
            {
                if(movement.y > 0f) 
                {
                    Vector3 desiredRotation = new Vector3(-45, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else if (movement.y < 0f)
                {
                    Vector3 desiredRotation = new Vector3(45, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else
                {
                    Vector3 desiredRotation = new Vector3(0, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
            }
            else if(movement.x >0f)
            {
                if (movement.y > 0f)
                {
                    Vector3 desiredRotation = new Vector3(-135, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else if (movement.y < 0f)
                {
                    Vector3 desiredRotation = new Vector3(180, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else
                {
                    Vector3 desiredRotation = new Vector3(180, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
            }
            else
            {
                if (movement.y > 0f)
                {
                    Vector3 desiredRotation = new Vector3(-90, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else if (movement.y < 0f)
                {
                    Vector3 desiredRotation = new Vector3(90, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                
            }
        }


    }


    void Jump()
    {
        // �÷��̾�� y �������� ���� �־� ����
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce/2, ForceMode.Impulse);
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(level);
        }
    }
}