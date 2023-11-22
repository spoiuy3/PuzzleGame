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
    

    public float rotationSpeed = 90.0f; // ȸ�� �ӵ� ����

    private bool isRotating = false;
    private float targetRotation = 0.0f;

    

    public void SwitchCamera()
    {

        if (c1.Priority>c2.Priority)  // ���� Orthographic ������ ���
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
            // ������ ȸ��
            float step = rotationSpeed * Time.deltaTime;
           
            a.transform.rotation = Quaternion.RotateTowards(a.transform.rotation, Quaternion.Euler(0, a.transform.rotation.eulerAngles.y, targetRotation), step);

            // ��ǥ ������ �����ϸ� ȸ�� ����
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
            // Ư�� Ű�� ������ ȸ�� ����
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
            // Ư�� Ű�� ������ ȸ�� ����
            targetRotation = 0.0f;
            isRotating = true;
        }

    }
    IEnumerator DelayedFunction1()
    {
        
        yield return new WaitForSeconds(1.7f);
        Debug.Log("1.6�� �ڿ� �����");
        movescript1.canMove = true;
    }
    IEnumerator DelayedFunction2()
    {

        yield return new WaitForSeconds(1.7f);
        Debug.Log("1.7�� �ڿ� �����");
        movescript1.canMove = true;
    }
}
