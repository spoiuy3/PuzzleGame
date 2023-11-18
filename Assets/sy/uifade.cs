using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class uifade : MonoBehaviour
{
    public Image uiImage;
    public float fadeOutDuration = 0.5f; // 페이드 아웃에 걸리는 시간
    public float fadeInDuration = 0.5f;
    
    private float currentAlpha = 1.0f; // 초기 투명도
    public static bool isStart;
    
    
    void Start()
    {
        isStart = false;
        movescript1.canMoveUI = false;
        uiImage.gameObject.SetActive(true);
        // 시작 시 투명도를 1.0으로 설정
        
        SetTransparency(currentAlpha);
    }

    void Update()
    {
        
        if (isStart)
        {
            // 1초 동안 서서히 투명도를 0으로 변경
            float elapsedTime = Time.deltaTime;
            currentAlpha = Mathf.Lerp(currentAlpha, 1f, elapsedTime / fadeInDuration);

            // 변경된 투명도를 UI 이미지에 적용
            SetTransparency(currentAlpha);
            StartCoroutine(Delayed());
            
        }
        else
        {
            // 1초 동안 서서히 투명도를 0으로 변경
            float elapsedTime = Time.deltaTime;
            
            currentAlpha = Mathf.Lerp(currentAlpha, 0.0f, elapsedTime / fadeOutDuration);

            // 변경된 투명도를 UI 이미지에 적용
            SetTransparency(currentAlpha);
            StartCoroutine(Delayed());
            
        }


    }

    void SetTransparency(float alpha)
    {
        // 현재 색상을 가져옴
        Color currentColor = uiImage.color;

        // 새로운 투명도 값을 적용
        currentColor.a = alpha;

        // 변경된 색상을 이미지에 적용
        uiImage.color = currentColor;
    }

    IEnumerator Delayed()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        movescript1.canMoveUI = true;
        
        
    }
}
