using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // �÷��̾��� Transform�� ������ ����
    public Vector3 offset = new Vector3(0f, 3f, -5f); // ī�޶�� �÷��̾� ������ ������� ��ġ ����

    void LateUpdate()
    {
        if (target != null)
        {
            // �÷��̾��� ��ġ�� offset�� ���Ͽ� ī�޶��� ��ġ ����
            transform.position = target.position + offset;

            // �÷��̾ ��� �ٶ󺸵��� ȸ��
            transform.LookAt(target);
        }
    }
}
