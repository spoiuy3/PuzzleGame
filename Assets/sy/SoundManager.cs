using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip backsound;
    public AudioClip jumpsound;
    public AudioClip deadsound;
    public AudioClip boxsound;
    public AudioClip clearsound;

    private AudioSource backsource;
    private AudioSource jumpsource;
    private AudioSource deadsource;
    private AudioSource boxsource;
    private AudioSource clearsource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // �̹� �ٸ� SoundManager �ν��Ͻ��� �ִٸ� �ı�
        }
    }

    void Start()
    {
        // �� ���� AudioSource ������Ʈ �߰�
        backsource = gameObject.AddComponent<AudioSource>();
        jumpsource = gameObject.AddComponent<AudioSource>();
        deadsource = gameObject.AddComponent<AudioSource>();
        boxsource = gameObject.AddComponent<AudioSource>();
        clearsource = gameObject.AddComponent<AudioSource>();

        // AudioClip ����
        backsource.clip = backsound;
        backsource.loop = true;
        backsource.volume = 0.3f;
        jumpsource.clip = jumpsound;
        jumpsource.loop = false;
        deadsource.clip = deadsound;
        deadsource.loop = false;
        boxsource.clip = boxsound;
        boxsource.loop = false;
        clearsource.clip = clearsound;
        clearsource.loop = false;
        jumpsource.volume = 0.2f;

    }

    public void PlaySound(int soundNumber)
    {
        // �Էµ� soundNumber�� ���� ������ AudioSource���� ���� ���
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
            case 4:
                boxsource.Play(); 
                break;
            case 5:
                clearsource.Play();
                break;
        }
    }

    public void StopSound(int soundNumber)
    {
        // �Էµ� soundNumber�� ���� ������ AudioSource���� ���� ���
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
            case 4:
                boxsource.Stop();
                break;
            case 5:
                clearsource.Stop();
                break;
        }
    }
}
