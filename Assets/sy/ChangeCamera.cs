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
    private int i = 0;

    public float rotationSpeed = 90.0f; // 회전 속도 조절

    private bool isRotating = false;
    private float targetRotation = 0.0f;

    

    public void SwitchCamera()
    {

        if (c1.Priority>c2.Priority)  // 현재 Orthographic 투영인 경우
        {
            c1.Priority = 0;  // 2D 카메라 비활성화
            c2.Priority = 1;  // 2.5D 카메라 활성화
            Physics.gravity = new Vector3(0f, 0f, 30f);
            Rotate1();
            StartCoroutine(DelayedFunction());
        }
        else
        {
            c1.Priority = 1;  // 2D 카메라 비활성화
            c2.Priority = 0;  // 2.5D 카메라 활성화
            Physics.gravity = new Vector3(0f, -30f, 0f);
            Rotate2();
            StartCoroutine(DelayedFunction());
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        interact.state = currentState;
        if(interact.state == "2d") { Physics.gravity = new Vector3(0f, -30f, 0f); }
        if (interact.state == "2_5d") { 
            Physics.gravity = new Vector3(0f, 0f, 30f);
            SwitchCamera();
        }
        
    }
    void Update()
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
            if (a.transform.rotation.eulerAngles.y==270f)
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
    IEnumerator DelayedFunction()
    {
        if (i == 0)
        {
            yield return new WaitForSeconds(0.1f);
            i++;
        }
            
        else
        {
            yield return new WaitForSeconds(2f);
        }

        // 여기에 1초 후에 실행될 코드를 넣습니다.
        Debug.Log("1초 뒤에 실행됨");
        movescript1.canMove = true;
    }
}
