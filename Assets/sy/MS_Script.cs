using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MS_Script : MonoBehaviour
{
    public CinemachineVirtualCamera forest_3d;
    public CinemachineVirtualCamera dungeon_3d;
    public CinemachineVirtualCamera player_3d;
    public CinemachineVirtualCamera dungeon_2d;
    public GameObject player;
    private int order;
    private int clear;
    public GameObject tobe;
    
    void Start()
    {
        
        gamesave.cine++;
        Physics.gravity = new Vector3(0, -30, 0);
        forest_3d.Priority = 1;
        dungeon_3d.Priority = 0;
        player_3d.Priority= 0;
        dungeon_2d.Priority = 0;
        order = gamesave.cine;
        clear = gamesave.curStage;
        if (clear <= 2 && clear > 0)
            player.transform.position += new Vector3(16f * clear, 0f, 0f);
        else if (clear > 2 && clear <= 4)
            player.transform.position = new Vector3(-38.55f + 16f * (clear - 3), 24.7f, -34.4f);
        else if (clear > 4 && clear <= 7)
            player.transform.position = new Vector3(13.3f + 18f * (clear - 5), 24.7f, -34.4f);
        else if (clear > 7)
            player.transform.position = new Vector3(85.9f + 12f * (clear - 8), 24.7f, -34.4f);
        if (order == 0)
            Delay();
        else
            Delay2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Delay()
    {
        if(order == 0)
        {
            movescript1.friction = 0f;
        }
        StartCoroutine(Del());
        Invoke("Delay1", 2.0f);
    }
    
    IEnumerator Del()
    {

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0f;
    }
    void Delay1()
    {
        forest_3d.Priority = 0;
        dungeon_3d.Priority = 1;
        player_3d.Priority = 0;
        StartCoroutine(Delay3());
        Invoke("Delay2", 8.0f);
    }
    void Delay2()
    {
        if(order != 0)
        {
            StartCoroutine(Delay4());
        }
        if (order == 11)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 0;
            dungeon_2d.Priority = 1;
            tobe.SetActive(true);
            movescript1.canMove = false;
            movescript1.friction = 0;
            Invoke("ResetGame", 6f);
        }
        else
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
            uifade.isStart = true;
        }
    }
    private void ResetGame()
    {
        SceneManager.LoadScene("GameStart");
    }
    IEnumerator Delay3()
    {
        yield return new WaitForSecondsRealtime(10f);
        movescript1.friction = 1f;
        movescript1.canMove = true;
    }
    IEnumerator Delay4()
    {
        yield return new WaitForSecondsRealtime(2f);
        movescript1.friction = 1f;
        movescript1.canMove = true;
    }
}
