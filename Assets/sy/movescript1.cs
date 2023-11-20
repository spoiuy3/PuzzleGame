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
    public static bool isGrounded; // 플레이어가 땅에 닿아 있는지 확인
    public static string level;
    public static bool haveKey;
    public static bool canMove = true;
    public static bool canMoveUI = true;
    private bool isObstacle;
    private int childNum1;
    //private int childNum2;
    Rigidbody rb;
    public static float friction = 1f; // 빙판에서의 마찰력 조절을 위한 변수
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
            if (Physics.Raycast(transform.position, Vector3.right, out hit1, 1f)) // 여기에서 1.0f는 레이의 길이입니다.
            {
                // 충돌한 물체가 벽인지 확인합니다.
                if (hit1.collider.tag == "Ground") // 벽의 태그에 맞게 수정하세요.
                {
                    Debug.Log("벽과 충돌했습니다!");

                    Vector3 move = new Vector3(0.1f, 0, 0);
                    transform.position -= move;

                }
            }
            if (Physics.Raycast(transform.position, Vector3.left, out hit2, 1f)) // 여기에서 1.0f는 레이의 길이입니다.
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
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Vector3 desiredRotation = new Vector3(-45, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    Vector3 desiredRotation = new Vector3(45, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else 
                {
                    Vector3 desiredRotation = new Vector3(0, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                

            }
            
            
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Vector3 desiredRotation = new Vector3(-135, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else
                {
                    Vector3 desiredRotation = new Vector3(-90, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Vector3 desiredRotation = new Vector3(135, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
                else
                {
                    Vector3 desiredRotation = new Vector3(180, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow)&&!Input.GetKey(KeyCode.LeftArrow))
            {
                
                
                    Vector3 desiredRotation = new Vector3(90, -90, 90);

                    // 오일러 각도를 쿼터니언으로 변환하여 설정
                    Quaternion desiredQuaternion = Quaternion.Euler(desiredRotation);
                    transform.rotation = desiredQuaternion;
                
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