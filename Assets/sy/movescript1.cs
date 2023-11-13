using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movescript1 : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절
    public float jumpForce = 10f; // 점프 힘 조절
    private bool isGrounded; // 플레이어가 땅에 닿아 있는지 확인
    public static string level;
    public static bool haveKey;
    public static bool canMove = true;
    

    BoxCollider boxCollider;
    void Start()
    {
        level = SceneManager.GetActiveScene().name;
        haveKey = false;
        boxCollider = GetComponent<BoxCollider>();

    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Jump") && isGrounded && Physics.gravity.y < 0f)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(level);
        }
    }

    void FixedUpdate()
    {

        // 키 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement;
        

        // 이동 벡터 계산
        if (Physics.gravity.y<0f)
        {
            movement = new Vector3(1.5f * horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        }
        else
        {
            movement = new Vector3(1.5f* horizontalInput, 1.5f*verticalInput,0f ) * moveSpeed * Time.deltaTime;
        }

        
        // 이동 적용
        if(canMove) { }
        else { movement = Vector3.zero; }
        transform.Translate(movement, Space.World);

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
            else if(movement.x > 0f)
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
            else if(movement.x >0f)
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
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce/2, ForceMode.Impulse);
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            DelayedFunction();
            SceneManager.LoadScene(level);
        }
    }

    IEnumerator DelayedFunction()
    {
        yield return new WaitForSeconds(2f);
    }


}