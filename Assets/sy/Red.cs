using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Red : MonoBehaviour
{
    private string state;
    private string level;
    private bool onTrigger;

    void Start()
    {
        onTrigger = false;
    }
    void Update()
    {
        level = movescript1.level;
        state = interact.state;
        if(Input.GetKeyDown(KeyCode.F) && movescript1.haveKey && state == "2_5d" && onTrigger)
        {
            SceneManager.LoadScene((int.Parse(level)+1).ToString());
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
