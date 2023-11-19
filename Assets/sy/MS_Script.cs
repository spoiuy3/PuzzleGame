using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MS_Script : MonoBehaviour
{
    public CinemachineVirtualCamera forest_3d;
    public CinemachineVirtualCamera dungeon_3d;
    public CinemachineVirtualCamera player_3d;
    public GameObject player;
    private int order;
    private int n;
    
    void Start()
    {
        Time.timeScale = 1.0f;
        Physics.gravity = new Vector3(0, -30, 0);
        forest_3d.Priority = 1;
        dungeon_3d.Priority = 0;
        player_3d.Priority= 0;
        order = gamesave.clearStage;
        if(order == -1)
            Delay();
        else
            Delay2();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gamesave.clearStage);
        
        if (order>=0)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
        }
    }
    void Delay()
    {
        movescript1.canMove = false;
        Invoke("Delay1", 2.0f);
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
        forest_3d.Priority = 0;
        dungeon_3d.Priority = 0;
        player_3d.Priority = 1;
    }
    IEnumerator Delay3()
    {
        yield return new WaitForSecondsRealtime(10f);
        
        movescript1.canMove = true;
    }
}
