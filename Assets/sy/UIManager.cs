using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AudioClip myAudioClip1; // Inspector���� ������ ����� Ŭ��
    public AudioClip myAudioClip2;
    public AudioClip myAudioClip3; // Inspector���� ������ ����� Ŭ��
    public AudioClip myAudioClip4;

    private AudioSource audioSource;
    public GameObject pause;
    public Button resume;
    public Button exit;
    public Button restart;
    public static bool isReady;
    // Update is called once per frame

    private void Start()
    {
        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();

        // ����� Ŭ�� ����
        
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
            // Ÿ�� ������Ʈ�� Ȱ��ȭ ���¸� ���

            pause.SetActive(!pause.activeSelf);
            if (pause.activeSelf)
            {
                audioSource.clip = myAudioClip1;
                audioSource.Play();
            }
                
        }
        if(!pause.activeSelf) { 
            Time.timeScale = 1.0f;
        }
        else
            Time.timeScale = 0.0f;
        
    }

    void Resume()
    {
        audioSource.clip = myAudioClip2;
        audioSource.Play();
        pause.SetActive(!pause.activeSelf);
    }

    void Exit()
    {
        audioSource.clip = myAudioClip3;
        audioSource.Play();
        isReady=false;
        pause.SetActive(!pause.activeSelf);
        StartCoroutine(Delay());
    }
    void Restart()
    {
        audioSource.clip = myAudioClip4;
        audioSource.Play();
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
