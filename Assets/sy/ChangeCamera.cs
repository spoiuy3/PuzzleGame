using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera mainCamera;
    public CinemachineVirtualCamera c1;
    public CinemachineVirtualCamera c2;
    void SwitchCamera()
    {
        if (c1.Priority>c2.Priority)  // 현재 Orthographic 투영인 경우
        {
            c1.Priority = 0;  // 2D 카메라 비활성화
            c2.Priority = 1;  // 2.5D 카메라 활성화
        }
        else
        {
            c1.Priority = 1;  // 2D 카메라 비활성화
            c2.Priority = 0;  // 2.5D 카메라 활성화
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))  // V 키를 눌렀을 때
        {
            SwitchCamera();  // 카메라 전환 함수 호출
        }
    }
}
