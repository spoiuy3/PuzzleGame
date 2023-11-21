using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip backsound;
    public AudioClip jumpsound;
    public AudioClip deadsound;

    private AudioSource backsource;
    private AudioSource jumpsource;
    private AudioSource deadsource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 이미 다른 SoundManager 인스턴스가 있다면 파괴
        }
    }

    void Start()
    {
        // 두 개의 AudioSource 컴포넌트 추가
        backsource = gameObject.AddComponent<AudioSource>();
        jumpsource = gameObject.AddComponent<AudioSource>();
        deadsource = gameObject.AddComponent<AudioSource>();

        // AudioClip 설정
        backsource.clip = backsound;
        backsource.loop = true;
        jumpsource.clip = jumpsound;
        jumpsource.loop = false;
        deadsource.clip = deadsound;
        deadsource.loop = false;

    }

    public void PlaySound(int soundNumber)
    {
        // 입력된 soundNumber에 따라 각각의 AudioSource에서 사운드 재생
        switch (soundNumber)
        {
            case 1:
                backsource.Play();
                break;
            case 2:
                jumpsource.Play();
                break;
            case 3:
                deadsource.Play();
                break;
                // 추가적인 사운드가 있다면 case를 계속해서 추가
        }
    }

    public void StopSound(int soundNumber)
    {
        // 입력된 soundNumber에 따라 각각의 AudioSource에서 사운드 재생
        switch (soundNumber)
        {
            case 1:
                backsource.Stop();
                break;
            case 2:
                jumpsource.Stop();
                break;
            case 3:
                deadsource.Stop();
                break;
                // 추가적인 사운드가 있다면 case를 계속해서 추가
        }
    }
}
