using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public GameObject pause;
    public Button resume;
    public Button exit;
    public Button restart;
    // Update is called once per frame

    private void Start()
    {
        pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Ÿ�� ������Ʈ�� Ȱ��ȭ ���¸� ���
            pause.SetActive(!pause.activeSelf);
        }
    }
}
