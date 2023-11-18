using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string level;
    private bool isTrig;
    private int clearStage;
    public GameObject Fire;

    void Start()
    {
        clearStage = gamesave.clearStage;
        isTrig = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrig && Input.GetKeyDown(KeyCode.F) && int.Parse(level)<=clearStage+1)
        {
            SceneManager.LoadScene(level);
        }
        if(int.Parse(level) <= clearStage)
        {
            Fire.SetActive(true);
        }
        else
            Fire.SetActive(false);

    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            isTrig = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            isTrig = false;
        }
    }
}
