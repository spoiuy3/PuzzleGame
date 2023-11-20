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
    private int curStage;
    private int clear;
    public GameObject tobe;
    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject block1;
    public GameObject block2;

    void Start()
    {
        
        gamesave.cine++;
        Physics.gravity = new Vector3(0, -30, 0);
        forest_3d.Priority = 1;
        dungeon_3d.Priority = 0;
        player_3d.Priority= 0;
        dungeon_2d.Priority = 0;
        order = gamesave.cine;
        curStage = gamesave.curStage;
        clear = gamesave.clearStage;
        if (curStage <= 2 && curStage > 0)
            player.transform.position += new Vector3(16f * curStage, 0f, 0f);
        else if (curStage > 2 && curStage <= 4)
            player.transform.position = new Vector3(-38.55f + 16f * (curStage - 3), 24.7f, -34.4f);
        else if (curStage > 4 && curStage <= 7)
            player.transform.position = new Vector3(13.3f + 18f * (curStage - 5), 24.7f, -34.4f);
        else if (curStage > 7)
            player.transform.position = new Vector3(85.9f + 12f * (curStage - 8), 24.7f, -34.4f);
        if (clear <= 4)
        {
            block1.SetActive(true);
            block2.SetActive(true);
            bridge1.SetActive(false);
            bridge2.SetActive(false);
        }

        else if (clear >4 && clear <= 7)
        {
            block1.SetActive(false);
            block2.SetActive(true);
            bridge1.SetActive(true);
            bridge2.SetActive(false);
        }
        else if (clear > 7)
        {
            block1.SetActive(false);
            block2.SetActive(false);
            bridge1.SetActive(true);
            bridge2.SetActive(true);
        }

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
        if (gamesave.clearStage == 11&&gamesave.end==0)
        {
            gamesave.end++;
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 0;
            dungeon_2d.Priority = 1;
            Invoke("B", 1.1f);
            Invoke("A", 2f);
            movescript1.canMove = false;
            movescript1.friction = 0;
            Invoke("ResetGame", 6f);
        }
        else
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
            
        }
    }
    private void ResetGame()
    {
        SceneManager.LoadScene("GameStart");
    }
    private void A()
    {
        tobe.SetActive(true);
    }
    void B()
    {
        uifade.isStart = true;
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
