using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // AudioClip 등 필요한 변수들을 설정

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Scene 전환 시 파괴되지 않도록 설정
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlaySound();
    }

    public void PlaySound()
    {
        // 사운드를 재생하는 코드 작성
        audioSource.Play();
    }
}
