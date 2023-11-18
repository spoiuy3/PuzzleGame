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
    private Vector3 currentVec;
    private int order;
    private bool canMove;
    public movescript1 movescript;
    void Start()
    {
        forest_3d.Priority = 1;
        dungeon_3d.Priority = 0;
        player_3d.Priority= 0;
        order = gamesave.clearStage-2;
        canMove = true;
        currentVec = player.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            player.GetComponent<movescript1>().MoveChange_false();
        }
        else
        {
            player.GetComponent <movescript1>().MoveChange_true();
        }
        if (order==-3)
        {
            canMove = false;
            Invoke("Delay1", 2.0f);
        }
        if (order==-2)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 1;
            player_3d.Priority = 0;
            Invoke("Delay2", 8.0f);
        }
        else if (order==-1)
        {
            canMove = true;
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
        }
        else if (order>=0)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
        }
    }

    void Delay1()
    {
        order = -2;
    }
    void Delay2()
    {
        order = -1;
    }
}
