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
            Destroy(gameObject); // �̹� �ٸ� SoundManager �ν��Ͻ��� �ִٸ� �ı�
        }
    }

    void Start()
    {
        // �� ���� AudioSource ������Ʈ �߰�
        backsource = gameObject.AddComponent<AudioSource>();
        jumpsource = gameObject.AddComponent<AudioSource>();
        deadsource = gameObject.AddComponent<AudioSource>();

        // AudioClip ����
        backsource.clip = backsound;
        backsource.loop = true;
        jumpsource.clip = jumpsound;
        jumpsource.loop = false;
        deadsource.clip = deadsound;
        deadsource.loop = false;

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
                // �߰����� ���尡 �ִٸ� case�� ����ؼ� �߰�
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
                // �߰����� ���尡 �ִٸ� case�� ����ؼ� �߰�
        }
    }
}
