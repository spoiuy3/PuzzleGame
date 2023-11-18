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
    private bool canMove;
    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        forest_3d.Priority = 1;
        dungeon_3d.Priority = 0;
        player_3d.Priority= 0;
        order = gamesave.clearStage;
        canMove = true;
        n = 0;
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
        if (order==-1)
        {
            if (n==0)
            {
                canMove = false;
                Invoke("Delay1", 2.0f);
            }
            else if (n == 1)
            {
                forest_3d.Priority = 0;
                dungeon_3d.Priority = 1;
                player_3d.Priority = 0;
                Invoke("Delay2", 8.0f);
            }
            else if (n==2)
            {
                canMove = true;
                forest_3d.Priority = 0;
                dungeon_3d.Priority = 0;
                player_3d.Priority = 1;
            }
        }
        if (order>=0)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
        }
    }

    void Delay1()
    {
        n = 1;
    }
    void Delay2()
    {
        n = 2;
    }
}
