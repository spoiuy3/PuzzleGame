using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mapselui : MonoBehaviour
{
    public AudioClip myAudioClip1; // Inspector에서 설정할 오디오 클립
    public AudioClip myAudioClip2;
    private AudioSource audioSource;
    public Button bt1;
    public Button bt2;
    public GameObject i;
    public static bool isReady =true;
    // Start is called before the first frame update
    void Start()
    {// AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // 오디오 클립 설정
        audioSource.clip = myAudioClip1;
        Invoke("temp", 0.1f);
        i.SetActive(false);
        bt1.onClick.AddListener(Yes);
        bt2.onClick.AddListener(No);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady && Input.GetKeyDown(KeyCode.Escape))
        {
            i.SetActive(!i.activeSelf);
            if (i.activeSelf)
            {
                PlayAudio();
            }
        }

        if (i.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void PlayAudio()
    {
        // 오디오 재생
        audioSource.Play();
    }
    void temp()
    {
        if (gamesave.cine == 0)
            Invoke("wait", 12f);
        else if (gamesave.clearStage == 11&&gamesave.end==0)
            Invoke("wait", 12f);
        else
            Invoke("wait", 1f);
    }
    void wait()
    {

        isReady = false;
    }
    void Yes()
    {
        audioSource.clip = myAudioClip2;
        audioSource.Play();
        i.SetActive (false);
        uifade.isStart = true;
        isReady = true;
        Invoke("Exit", 1f);
    }
    void No()
    {
        i.SetActive(false);
    }
    void Exit()
    {
        SceneManager.LoadScene("GameStart");
    }
}
