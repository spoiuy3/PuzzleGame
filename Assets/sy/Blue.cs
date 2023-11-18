using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blue : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.F) && interact.haveKey && state == "2d" && onTrigger)
        {
            gamesave.clearStage = level;
            movescript1.canMove = false;
            StartCoroutine(Delay());
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

    IEnumerator Delay()
    {
        uifade.isStart = true;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("MapSelect");
    }
}
