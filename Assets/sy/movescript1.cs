using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class movescript1 : MonoBehaviour
{
    private float lastdir;

    [SerializeField, Range(0f, 100f)]
    private float moveSpeed2 = 5f;
        [SerializeField, Range(0f, 100f)]
    private float moveSpeed25 = 5f;
    [SerializeField, Range(0f, 100f)]
    private float jumpForce = 5f;
    public static bool isGrounded; // �÷��̾ ���� ��� �ִ��� Ȯ��
    public static string level;
    public static bool haveKey;
    public static bool canMove = true;
    public static bool canMoveUI = true;
    private bool isObstacle;
    private int childNum1;
    //private int childNum2;
    Rigidbody rb;
    public static float friction = 1f; // ���ǿ����� ������ ������ ���� ����
    public float slideSpeed = 2f;
    public static Vector3 movement;
    private float scaleSpeed = 0.008f;
    private Vector3 currentScale;
    private float horizontalInput;
    private float verticalInput;

    BoxCollider boxCollider;
    void Start()
    {
        canMove = true;
        level = SceneManager.GetActiveScene().name;
        haveKey = false;
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        isObstacle = false;

    }

    private void Update()
    {



        if (Input.GetButtonDown("Jump") && isGrounded && Physics.gravity.y < 0f && canMove)
        {
            Jump();
        }

        
        RaycastHit hit1, hit2;
        if(Physics.gravity.y < 0f)
        {
            if (Physics.Raycast(transform.position, Vector3.right, out hit1, 1f)) // ���⿡�� 1.0f�� ������ �����Դϴ�.
            {
                // �浹�� ��ü�� ������ Ȯ���մϴ�.
                if (hit1.collider.tag == "Ground") // ���� �±׿� �°� �����ϼ���.
                {
                    Debug.Log("���� �浹�߽��ϴ�!");

                    Vector3 move = new Vector3(0.1f, 0, 0);
                    transform.position -= move;

                }
            }
            if (Physics.Raycast(transform.position, Vector3.left, out hit2, 1f)) // ���⿡�� 1.0f�� ������ �����Դϴ�.
            {
                // �浹�� ��ü�� ������ Ȯ���մϴ�.
                if (hit2.collider.tag == "Ground") // ���� �±׿� �°� �����ϼ���.
                {
                    Debug.Log("���� �浹�߽��ϴ�!");

                    Vector3 move = new Vector3(-0.1f, 0, 0);
                    transform.position -= move;

                }
            }
        }
        
        if(isObstacle)
        {
            Player_rotate();
        }
        
        


    }

    void FixedUpdate()
    {
        if(canMove&&canMoveUI)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }


        // �̵� ���� ���
        if (Physics.gravity.y < 0f)
        {
            
            movement = new Vector3(1.5f * horizontalInput, 0f, 0f) * moveSpeed2 * Time.deltaTime;
            movement.x *= friction;
        }
        else
        {
            movement = new Vector3(1.5f * horizontalInput, 1.5f * verticalInput, 0f) * moveSpeed25 * Time.deltaTime;
            
        }
        
        
        if (Physics.gravity.y < 0 )
        {
            if (movement.x > 0 && movement.magnitude > 0.01f)
            {
                movement += Vector3.right * slideSpeed * Time.deltaTime;
            }
            else if (movement.x < 0&&movement.magnitude > 0.01f) {
                movement += Vector3.left * slideSpeed * Time.deltaTime;
            }

        }
        



        
        if (!canMove)
            rb.velocity = Vector3.zero;

        // �̵� ����
        if (canMove) { }
        else { movement = Vector3.zero; }
        if(Physics.gravity.y < 0)
        {
            rb.MovePosition(transform.position + movement);
        }
        else
        {
            transform.position += movement;
        }
        
        
        if (Physics.gravity.y < 0f)
        {
            if (movement.x < 0f)
            {
                Vector3 desiredRotation = new Vector3(0, -90, 0);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
            else if (movement.x > 0f)
            {
                Vector3 desiredRotation = new Vector3(0, 90, 0);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
        }
        else
        {
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Vector3 desiredRotation = new Vector3(-45, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }

                else if (Input.GetKey(KeyCode.DownArrow))
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
            
            
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Vector3 desiredRotation = new Vector3(-135, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else
                {
                    Vector3 desiredRotation = new Vector3(-90, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Vector3 desiredRotation = new Vector3(135, -90, 90);

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
            else if (Input.GetKey(KeyCode.DownArrow)&&!Input.GetKey(KeyCode.LeftArrow))
            {
                
                
                    Vector3 desiredRotation = new Vector3(90, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                
            }




        }



    }


    void Jump()
    {
        // �÷��̾�� y �������� ���� �־� ����
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            canMove = false;
            isObstacle = true;
            StartCoroutine(DelayedFunction());
        }
    }

    IEnumerator DelayedFunction()
    {
        yield return new WaitForSeconds(2.5f);
        canMove = true;
        SceneManager.LoadScene(level);
    }
    

    void Player_rotate()
    {
        transform.Rotate(Vector3.up, 2f);
    }

    public void MoveChange_false()
    {
        canMove = false;
    }
    public void MoveChange_true()
    {
        canMove = true;
    }
}