using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class BeginScript : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source;
    public AudioClip myAudioClip1; // Inspector에서 설정할 오디오 클립
    public AudioClip myAudioClip2;
    public AudioClip myAudioClip3;

    private AudioSource audioSource;
    private float scaleSpeed = 0.01f;
    private float jumpSpeed = 0.1f;
    private bool getSmall_devil;
    private bool getSmall_player;
    private bool canJump_devil;
    private bool canJump_player;
    private int n;
    private int order;
    private bool hasFunctionExecuted_order;
    private bool canRoate;
    private bool canMove;
    private float x;
    private float z;

    public GameObject player;
    public GameObject devil;
    public CinemachineVirtualCamera forest_3d;
    public CinemachineVirtualCamera forest_2d;
    public CinemachineVirtualCamera winter_3d;
    public CinemachineVirtualCamera winter_2d;
    public CinemachineVirtualCamera dungeon_3d;
    public CinemachineVirtualCamera dungeon_2d;
    int a=0;
    int b = 0;
    int c = 0;

    private Vector3 currentScale_devil;
    private Vector3 currentScele_player;
    private bool isPlay;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        forest_3d.Priority = 1;
        forest_2d.Priority = 0;
        winter_3d.Priority = 0;
        winter_2d.Priority = 0;
        dungeon_2d.Priority = 0;
        dungeon_3d.Priority = 0;
        currentScale_devil = devil.transform.localScale;
        currentScele_player = player.transform.localScale;
        getSmall_devil = true;
        canJump_devil = true;
        canJump_player = true;
        canRoate = true;
        canMove=true;
        n = 0;
        order = 0;
        hasFunctionExecuted_order = false;
        isPlay = false;
        source.clip = sound;
        source.volume = 0.45f;
        source.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(order ==0)
        {
            Invoke("OrderPlus0", 2.0f);
        }
        if (order == 1)
        {
            hasFunctionExecuted_order = false;
            forest_3d.Priority = 1;
            forest_2d.Priority = 0;
            Player_Walk_();
            Player_Jump();
            Player_Idle();

            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus1", 3.2f);
                
            }
        }
        if (order == 2)
        {
            hasFunctionExecuted_order = false;
            player.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            Player_Walk();
            Player_Jump();
            Player_Idle();

            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus2", 2.5f);
                
            }
        }
        else if (order == 3)
        {
            hasFunctionExecuted_order = false;
            if(player.transform.localPosition.y > 24.7f)
            {
                Player_Walk();
                Player_Jump();
                Player_Idle();
            }
            Devil_JumpId();
            Devil_Walk();
            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus3", 3.5f);
                
            }
        }
        else if(order == 4)
        {
            hasFunctionExecuted_order = false;

            if(devil.transform.localPosition.y > -0.03223419f)
            {
                Devil_JumpId();
                Devil_Walk();
            }
            else
            {
                
                Devil_Idle();
            }
                

            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus4", 1.0f);
                
            }
        }
        else if (order == 5)
        {
            hasFunctionExecuted_order = false;

            Devil_Angry();

            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus5", 2.3f);
                
            }
        }

        else if (order == 6)
        {
            hasFunctionExecuted_order = false;
            if(devil.transform.localRotation.z>0.001f || devil.transform.localRotation.z < -0.001f)
            {
                Devil_Angry();
            }
            else
                Devil_Jump();

            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus6", 1.7f);
                
            }
        }    
        
        else if (order == 7)
        {
            hasFunctionExecuted_order = false;
            Invoke("Cam", 1f);
            x = player.transform.localPosition.x;
            z = player.transform.localPosition.z;
            player.transform.localPosition = new Vector3 (x, 24.61f, z);
            if (devil.transform.localPosition.y > -0.03223419f)
            {
                Devil_Jump();
            }
            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus7", 2.5f);
                
            }
        }
        else if (order == 8)
        {
            hasFunctionExecuted_order = false;
            Player_rotate();
            if(!isPlay)
            {
                isPlay = true;
                audioSource.clip = myAudioClip3;
                audioSource.Play();
            }
            if (devil.transform.localPosition.x < 152.0883f)
            {
                Devil_Walk_();
            }
            if (!hasFunctionExecuted_order)
            {
                Invoke("OrderPlus8", 4.0f);
                
            }
        }
        else if (order == 9)
        {
            StartCoroutine(Delay());
        }
    }

    void Cam()
    {
        forest_3d.Priority = 0;
        forest_2d.Priority = 1;
    }
    void Devil_Idle()
    {
        
        if (b++ == 0)
        {
            
            Invoke("Sound2", 0.5f);
        }
        if (getSmall_devil && currentScale_devil.y > 2.5f)
        {
            currentScale_devil.y -= scaleSpeed;
            devil.transform.localScale = currentScale_devil;
        }
        else if (!getSmall_devil && 3.0f > currentScale_devil.y)
        {
            currentScale_devil.y += scaleSpeed;
            devil.transform.localScale = currentScale_devil;
        }
        if (2.4f < currentScale_devil.y && currentScale_devil.y < 2.5f)
            getSmall_devil = false;
        else if (currentScale_devil.y == 3.0f)
            getSmall_devil = true;
    }

    void Player_Idle()
    {
        if (getSmall_player && currentScele_player.y > 5.0f)
        {
            currentScele_player.y -= scaleSpeed;
            player.transform.localScale = currentScele_player;
            player.transform.localPosition += new Vector3(0f, scaleSpeed, 0f);
        }
        else if (!getSmall_player && 6.0f > currentScele_player.y)
        {
            currentScele_player.y += scaleSpeed;
            player.transform.localScale = currentScele_player;
            player.transform.localPosition -= new Vector3(0f, scaleSpeed, 0f);
        }
        if (4.9f < currentScele_player.y && currentScele_player.y < 5.0f)
            getSmall_player = false;
        else if (currentScele_player.y == 6.0f)
            getSmall_player = true;
    }

    void Player_Jump()
    {
        if (canJump_player && player.transform.localPosition.y < 26.0f)
        {
            
            player.transform.localPosition += new Vector3(0f, 0.03f, 0f);
            
        }
        else if (!canJump_player && player.transform.localPosition.y > 24.7f)
        {
            player.transform.localPosition -= new Vector3(0f, 0.03f, 0f);
        }
        else if (player.transform.localPosition.y < 26.1f && player.transform.localPosition.y >= 24.7f)
        {
            Invoke("PlayerLand", 0.5f);
        }
        if(player.transform.localPosition.y >= 24.6f && player.transform.localPosition.y <= 24.7f)
        {
            canJump_player = true;
        }
    }

    void Player_Walk()
    {
        player.transform.localPosition += new Vector3(0.01f, 0f, 0f);
    }

    void Player_Walk_()
    {
        player.transform.localPosition -= new Vector3(0.01f, 0f, 0f);
    }
    void Player_rotate()
    {
        player.transform.Rotate(Vector3.up, 2f);
    }

    void Devil_Walk()
    {
        if (canMove)
        {
            devil.transform.localPosition -= new Vector3(0.03f, 0f, 0f);
        }
        
    }

    void Devil_Walk_()
    {
        if (canMove)
        {
            devil.transform.localPosition += new Vector3(0.1f, 0f, 0f);
        }

    }

    void Devil_JumpId()
    {
        if (canJump_devil && devil.transform.localPosition.y < 5.0f)
        {
            devil.transform.localPosition += new Vector3(0f, 0.08f, 0f);
        }
        else if (!canJump_devil && devil.transform.localPosition.y > -0.03224564f)
        {
            devil.transform.localPosition -= new Vector3(0f, 0.08f, 0f);
        }
        else if (devil.transform.localPosition.y < 5.1f && devil.transform.localPosition.y >= 5.0f)
        {
            a = 0;
            Invoke("DevilLand", 0.1f);
        }
        if (devil.transform.localPosition.y >= -0.33224564f && devil.transform.localPosition.y <= -0.003224564f)
        {
            canMove = false;
            Invoke("DevilLand_", 0.3f);
            Invoke("DevilMove", 0.3f);
        }
    }

    void Devil_Angry()
    {
        if (canRoate && devil.transform.localRotation.z > -0.15f)
        {
            
            devil.transform.Rotate(Vector3.forward, -0.7f);
        }
        else if (!canRoate && devil.transform.localRotation.z < 0.15f)
        {
            devil.transform.Rotate(Vector3.forward, 0.7f);
        }
        if (devil.transform.localRotation.z > -0.16f && devil.transform.localRotation.z <= -0.14f)
        {
            canRoate = false;
        }
        else if (devil.transform.localRotation.z < 0.16f && devil.transform.localRotation.z >= 0.14f)
        {
            canRoate = true;
        }
    }

    void Devil_Jump()
    {
        if (canJump_devil && devil.transform.localPosition.y < 10.0f)
        {
            devil.transform.localPosition += new Vector3(0f, jumpSpeed, 0f);
        }
        else if (!canJump_devil && devil.transform.localPosition.y > -0.03224564f)
        {
            devil.transform.localPosition -= new Vector3(0f, 0.2f, 0f);
        }
        else if (devil.transform.localPosition.y < 10.1f && devil.transform.localPosition.y >= 10.0f)
        {
            a = 0;
            Invoke("DevilLand", 0.3f);
        }
    }
    void OrderPlus0()
    {
        order = 1;
    }

    void OrderPlus1()
    {
        order=2;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus2()
    {
        order = 3;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus3()
    {
        order = 4;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus4()
    {
        order = 5;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus5()
    {
        order = 6;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus6()
    {
        order = 7;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus7()
    {
        order = 8;
        hasFunctionExecuted_order = true;
    }
    void OrderPlus8()
    {
        order = 9;
        hasFunctionExecuted_order = true;
    }
    void PlayerLand()
    {
        canJump_player = false;
    }
    void DevilLand()
    {
        
        
        if (a++ == 0)
        {
            audioSource.clip = myAudioClip1;
            audioSource.volume = 1.1f;
            Invoke("Sound", 0.2f);
        }
        
        canJump_devil = false;
    }
    void DevilLand_()
    {
        canJump_devil = true;
    }
    void DevilMove()
    {
        canMove = true;
    }
    void Sound()
    {
        audioSource.Play();
    }
    void Sound2()
    {
        audioSource.clip = myAudioClip2;
        audioSource.volume = 1f;
        audioSource.Play();
    }
    IEnumerator Delay()
    {
        uifade.isStart = true;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("MapSelect");
    }
}