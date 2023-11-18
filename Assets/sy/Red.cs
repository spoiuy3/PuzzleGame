using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Red : MonoBehaviour
{
    private string state;
    public int level;
    private bool onTrigger;

    void Start()
    {
        onTrigger = false;
    }
    void Update()
    {
        
        state = interact.state;
        if(Input.GetKeyDown(KeyCode.F) && interact.haveKey && state == "2_5d" && onTrigger)
        {
            gamesave.clearStage = level;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }
}
