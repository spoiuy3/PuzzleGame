using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class movescript1 : MonoBehaviour
{


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
    public GameObject background;
    private GameObject[] backgrounds;
    private int childNum1;
    //private int childNum2;
    Rigidbody rb;
    public float friction = 0.95f; // ���ǿ����� ������ ������ ���� ����
    public float slideSpeed = 2f;
    public static Vector3 movement;
    private float scaleSpeed = 0.008f;
    private Vector3 currentScale;

    BoxCollider boxCollider;
    void Start()
    {
        // background �ڽĵ� �־��ֱ�
        childNum1 = background.transform.childCount;
        backgrounds = new GameObject[childNum1];
        for (int i = 0; i < childNum1; i++)
        {
            backgrounds[i] = background.transform.GetChild(i).gameObject;
        }

        level = SceneManager.GetActiveScene().name;
        haveKey = false;
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {



        if (Input.GetButtonDown("Jump") && isGrounded && Physics.gravity.y < 0f && canMove)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            canMove = false;
            for (int i = 0; i < childNum1; i++)
            {
                backgrounds[i].GetComponent<Rigidbody>().isKinematic = false;
            }

            StartCoroutine(DelayedFunction());
        }
        RaycastHit hit1, hit2;
        if (Physics.Raycast(transform.position, Vector3.right, out hit1, 1f) && Physics.gravity.y < 0f) // ���⿡�� 1.0f�� ������ �����Դϴ�.
        {
            // �浹�� ��ü�� ������ Ȯ���մϴ�.
            if (hit1.collider.tag == "Ground") // ���� �±׿� �°� �����ϼ���.
            {
                Debug.Log("���� �浹�߽��ϴ�!");

                Vector3 move = new Vector3(0.1f, 0, 0);
                transform.position -= move;

            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit2, 1f) && Physics.gravity.y < 0f) // ���⿡�� 1.0f�� ������ �����Դϴ�.
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

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


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
            if (movement.x < 0f)
            {


                Vector3 desiredRotation = new Vector3(0, -90, 90);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;

            }
            else if (movement.x > 0f)
            {


                Vector3 desiredRotation = new Vector3(180, -90, 90);

                // ���Ϸ� ������ ���ʹϾ����� ��ȯ�Ͽ� ����
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;


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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            canMove = false;
            for (int i = 0; i < childNum1; i++)
            {
                backgrounds[i].GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(DelayedFunction());
        }
    }

    IEnumerator DelayedFunction()
    {
        yield return new WaitForSeconds(2.5f);
        canMove = true;
        SceneManager.LoadScene(level);
    }
    IEnumerator DelayedFunction_()
    {
        yield return new WaitForSeconds(1.0f);
    }


}