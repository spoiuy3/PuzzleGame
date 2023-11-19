using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public GameObject pause;
    public Button resume;
    public Button exit;
    public Button restart;
    public static bool isReady;
    // Update is called once per frame

    private void Start()
    {
        isReady = true;
        pause.SetActive(false);
        resume.onClick.AddListener(Resume);
        exit.onClick.AddListener(Exit);
        restart.onClick.AddListener(Restart);
        StartCoroutine(D());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !isReady)
        {
            // 타겟 오브젝트의 활성화 상태를 토글
            pause.SetActive(!pause.activeSelf);
        }
        if(!pause.activeSelf) { 
            Time.timeScale = 1.0f;
        }
        else
            Time.timeScale = 0.0f;
        
    }

    void Resume()
    {
        pause.SetActive(!pause.activeSelf);
    }

    void Exit()
    {
        isReady=false;
        pause.SetActive(!pause.activeSelf);
        StartCoroutine(Delay());
    }
    void Restart()
    {
        pause.SetActive(!pause.activeSelf);
        isReady = true;
        uifade.isStart = true;
        movescript1.canMove = false;
        StartCoroutine(Delayed());
    }

    IEnumerator Delayed()
    {
        string name = SceneManager.GetActiveScene().name;
        
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(name);
    }
    IEnumerator Delay()
    {
        uifade.isStart = true;
        movescript1.canMove = false;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("MapSelect");
        
    }
    IEnumerator D()
    {
        
        movescript1.canMove = false;
        
        yield return new WaitForSecondsRealtime(1f);
        movescript1.canMove = true;
        isReady = false;

    }
}
