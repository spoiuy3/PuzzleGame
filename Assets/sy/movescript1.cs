using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movescript1 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private bool isMoving = false;
    [SerializeField, Range(0f, 100f)]
    private float moveSpeed = 5f;

    [SerializeField, Range(0f, 100f)]
    private float jumpForce = 5f;
    private bool isGrounded; // �÷��̾ ���� ��� �ִ��� Ȯ��
    public static string level;
    public static bool haveKey;
    public static bool canMove = true;
    

    BoxCollider boxCollider;
    void Start()
    {
        if (!TryGetComponent(out rb))
            rb = gameObject.AddComponent<Rigidbody>();
        level = SceneManager.GetActiveScene().name;
        haveKey = false;
        boxCollider = GetComponent<BoxCollider>();

    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        isMoving = (h != 0f || v != 0f);

        if (isMoving && Physics.gravity.z>0)
        {
            moveDir = transform.forward * h + transform.right * -1* v;
            moveDir.Normalize();
        }
        else
        {
            moveDir = transform.forward * h;
            moveDir.Normalize();
        }
        if (Input.GetButtonDown("Jump") && isGrounded && Physics.gravity.y < 0f)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            canMove = false;
            StartCoroutine(DelayedFunction());
            
        }
    }

    void FixedUpdate()
    {

        if (isMoving && canMove)
        {
            Vector3 moveOffset = moveDir * (moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + moveOffset);
        }


       
        

        

        
        
        /*if (Physics.gravity.y < 0f)
        {
            if (rb.velocity.x < 0f)
            {
                Vector3 desiredRotation = new Vector3(0, -90, 0);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
            else if(rb.velocity.x > 0f)
            {
                Vector3 desiredRotation = new Vector3(0, 90, 0);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
        }
        else
        {
            if (rb.velocity.x < 0f)
            {
                
                
                    Vector3 desiredRotation = new Vector3(0, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                
            }
            else if(rb.velocity.x >0f)
            {
                
                
                    Vector3 desiredRotation = new Vector3(180, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                
                
            }
            else
            {
                if (rb.velocity.y > 0f)
                {
                    Vector3 desiredRotation = new Vector3(-90, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else if (rb.velocity.y < 0f)
                {
                    Vector3 desiredRotation = new Vector3(90, -90, 90);

                    // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                
            }
        }*/


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
            canMove = false;
            StartCoroutine(DelayedFunction());
            
        }
    }

    IEnumerator DelayedFunction()
    {
        yield return new WaitForSeconds(1f);
        canMove = true;
        SceneManager.LoadScene(level);
    }


}