using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera mainCamera;
    public CinemachineVirtualCamera c1;
    public CinemachineVirtualCamera c2;
    public GameObject a;
    public string currentState;
    

    public float rotationSpeed = 90.0f; // 회전 속도 조절

    private bool isRotating = false;
    private float targetRotation = 0.0f;

    

    public void SwitchCamera()
    {

        if (c1.Priority>c2.Priority)  // 현재 Orthographic 투영인 경우
        {
            movescript1.canMove = false;
            c1.Priority = 0;  
            c2.Priority = 1;  
            Physics.gravity = new Vector3(0f, 0f, 30f);
            Rotate1();
            StartCoroutine(DelayedFunction1());
        }
        else
        {
            movescript1.canMove = false;
            c1.Priority = 1;  
            c2.Priority = 0;  
            Physics.gravity = new Vector3(0f, -30f, 0f);
            Rotate2();
            StartCoroutine(DelayedFunction2());
        }
    }

    // Start is called before the first frame update
    void Awake()
    {

        interact.state = currentState;
        
        if(interact.state == "2d") { Physics.gravity = new Vector3(0f, -30f, 0f);
            
        }
        else if (interact.state == "2_5d") { 
            Physics.gravity = new Vector3(0f, 0f, 30f);
           
        }
        
    }
    void FixedUpdate()
    {
        
        if (isRotating)
        {
            // 서서히 회전
            float step = rotationSpeed * Time.deltaTime;
           
            a.transform.rotation = Quaternion.RotateTowards(a.transform.rotation, Quaternion.Euler(0, a.transform.rotation.eulerAngles.y, targetRotation), step);

            // 목표 각도에 도달하면 회전 중지
            if (Quaternion.Angle(a.transform.rotation, Quaternion.Euler(0, a.transform.rotation.eulerAngles.y, targetRotation)) < 0.1f)
            {
                isRotating = false;
                
            }
        }
    }
    public void Rotate1()
    {
        if (!isRotating)
        {
            // 특정 키를 누르면 회전 시작
            if (a.transform.rotation.eulerAngles.y==270)
            {
                targetRotation = 90f;
                
            }
            else
            {
                targetRotation = -90f;
            }
            isRotating = true;
        }

    }
    public void Rotate2()
    {
        if (!isRotating)
        {
            // 특정 키를 누르면 회전 시작
            targetRotation = 0.0f;
            isRotating = true;
        }

    }
    IEnumerator DelayedFunction1()
    {
        
        yield return new WaitForSeconds(1.7f);
        Debug.Log("1.6초 뒤에 실행됨");
        movescript1.canMove = true;
    }
    IEnumerator DelayedFunction2()
    {

        yield return new WaitForSeconds(1.7f);
        Debug.Log("1.7초 뒤에 실행됨");
        movescript1.canMove = true;
    }
}
