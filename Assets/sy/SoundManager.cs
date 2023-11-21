using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // AudioClip �� �ʿ��� �������� ����

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Scene ��ȯ �� �ı����� �ʵ��� ����
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
        // ���带 ����ϴ� �ڵ� �ۼ�
        audioSource.Play();
    }
}
