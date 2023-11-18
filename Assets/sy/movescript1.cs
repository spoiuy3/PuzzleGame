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
    public static bool isGrounded; // 플레이어가 땅에 닿아 있는지 확인
    public static string level;
    public static bool haveKey;
    public static bool canMove = true;
    public GameObject background;
    private GameObject[] backgrounds;
    private int childNum1;
    //private int childNum2;
    Rigidbody rb;
    public float friction = 0.95f; // 빙판에서의 마찰력 조절을 위한 변수
    public float slideSpeed = 2f;
    public static Vector3 movement;
    private float scaleSpeed = 0.008f;
    private Vector3 currentScale;

    BoxCollider boxCollider;
    void Start()
    {
        // background 자식들 넣어주기
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
        if (Physics.Raycast(transform.position, Vector3.right, out hit1, 1f) && Physics.gravity.y < 0f) // 여기에서 1.0f는 레이의 길이입니다.
        {
            // 충돌한 물체가 벽인지 확인합니다.
            if (hit1.collider.tag == "Ground") // 벽의 태그에 맞게 수정하세요.
            {
                Debug.Log("벽과 충돌했습니다!");

                Vector3 move = new Vector3(0.1f, 0, 0);
                transform.position -= move;

            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit2, 1f) && Physics.gravity.y < 0f) // 여기에서 1.0f는 레이의 길이입니다.
        {
            // 충돌한 물체가 벽인지 확인합니다.
            if (hit2.collider.tag == "Ground") // 벽의 태그에 맞게 수정하세요.
            {
                Debug.Log("벽과 충돌했습니다!");

                Vector3 move = new Vector3(-0.1f, 0, 0);
                transform.position -= move;

            }
        }
        



    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // 이동 벡터 계산
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

        // 이동 적용
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
        
        // 점프 처리
        if (Physics.gravity.y < 0f)
        {
            if (movement.x < 0f)
            {
                Vector3 desiredRotation = new Vector3(0, -90, 0);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
            else if (movement.x > 0f)
            {
                Vector3 desiredRotation = new Vector3(0, 90, 0);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;
            }
        }
        else
        {
            if (movement.x < 0f)
            {


                Vector3 desiredRotation = new Vector3(0, -90, 90);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;

            }
            else if (movement.x > 0f)
            {


                Vector3 desiredRotation = new Vector3(180, -90, 90);

                // 오일러 각도를 쿼터니언으로 변환하여 설정
                Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                transform.rotation = desiredQuaternion;


            }
            else
            {
                if (movement.y > 0f)
                {
                    Vector3 desiredRotation = new Vector3(-90, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else if (movement.y < 0f)
                {
                    Vector3 desiredRotation = new Vector3(90, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }

            }
        }



    }


    void Jump()
    {
        // 플레이어에게 y 방향으로 힘을 주어 점프
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
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