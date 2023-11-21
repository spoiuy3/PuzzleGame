using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform을 참조할 변수
    public Vector3 offset = new Vector3(0f, 3f, -5f); // 카메라와 플레이어 사이의 상대적인 위치 조절

    void LateUpdate()
    {
        if (target != null)
        {
            // 플레이어의 위치에 offset을 더하여 카메라의 위치 설정
            transform.position = target.position + offset;

            // 플레이어를 계속 바라보도록 회전
            transform.LookAt(target);
        }
    }
}
