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
        if (c1.Priority>c2.Priority)  // ���� Orthographic ������ ���
        {
            c1.Priority = 0;  // 2D ī�޶� ��Ȱ��ȭ
            c2.Priority = 1;  // 2.5D ī�޶� Ȱ��ȭ
        }
        else
        {
            c1.Priority = 1;  // 2D ī�޶� ��Ȱ��ȭ
            c2.Priority = 0;  // 2.5D ī�޶� Ȱ��ȭ
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))  // V Ű�� ������ ��
        {
            SwitchCamera();  // ī�޶� ��ȯ �Լ� ȣ��
        }
    }
}
