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
    // Update is called once per frame

    private void Start()
    {
        pause.SetActive(false);
        resume.onClick.AddListener(Resume);
        exit.onClick.AddListener(Exit);
        restart.onClick.AddListener(Restart);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene("MapSelect");
    }
    void Restart()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
}
