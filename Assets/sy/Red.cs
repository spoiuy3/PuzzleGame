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
            movescript1.canMove = false;
            SoundManager.instance.StopSound(1);
            SoundManager.instance.PlaySound(5);
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
        UIManager.isReady = true;
        uifade.isStart = true;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("MapSelect");
        
    }
}
