using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class uifade : MonoBehaviour
{
    public Image uiImage;
    public float fadeOutDuration = 0.5f; // ���̵� �ƿ��� �ɸ��� �ð�
    public float fadeInDuration = 0.5f;
    
    private float currentAlpha = 1.0f; // �ʱ� ����
    public static bool isStart;
    
    
    void Start()
    {
        isStart = false;
        movescript1.canMoveUI = false;
        uiImage.gameObject.SetActive(true);
        // ���� �� ������ 1.0���� ����
        
        SetTransparency(currentAlpha);
    }

    void Update()
    {
        
        if (isStart)
        {
            // 1�� ���� ������ ������ 0���� ����
            float elapsedTime = Time.deltaTime;
            currentAlpha = Mathf.Lerp(currentAlpha, 1f, elapsedTime / fadeInDuration);

            // ����� ������ UI �̹����� ����
            SetTransparency(currentAlpha);
            StartCoroutine(Delayed());
            
        }
        else
        {
            // 1�� ���� ������ ������ 0���� ����
            float elapsedTime = Time.deltaTime;
            
            currentAlpha = Mathf.Lerp(currentAlpha, 0.0f, elapsedTime / fadeOutDuration);

            // ����� ������ UI �̹����� ����
            SetTransparency(currentAlpha);
            StartCoroutine(Delayed());
            
        }


    }

    void SetTransparency(float alpha)
    {
        // ���� ������ ������
        Color currentColor = uiImage.color;

        // ���ο� ���� ���� ����
        currentColor.a = alpha;

        // ����� ������ �̹����� ����
        uiImage.color = currentColor;
    }

    IEnumerator Delayed()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        movescript1.canMoveUI = true;
        
        
    }
}
