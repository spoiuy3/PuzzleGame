using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_Script : MonoBehaviour
{
    public CinemachineVirtualCamera forest_3d;
    public CinemachineVirtualCamera dungeon_3d;
    public CinemachineVirtualCamera player_3d;
    private int order;
    void Start()
    {
        forest_3d.Priority = 1;
        dungeon_3d.Priority = 0;
        player_3d.Priority= 0;
        order = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (order==-1)
        {
            Invoke("Delay1", 2.0f);
        }
        if (order==0)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 1;
            player_3d.Priority = 0;
            Invoke("Delay2", 8.0f);
        }
        else if (order==1)
        {
            forest_3d.Priority = 0;
            dungeon_3d.Priority = 0;
            player_3d.Priority = 1;
        }
    }

    void Delay1()
    {
        order = 0;
    }
    void Delay2()
    {
        order = 1;
    }
}
