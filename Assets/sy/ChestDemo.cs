using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;
    private bool opened = false;
    private bool istrig = false;

	// Use this for initialization
	void Awake ()
    {
        //get the Animator component from the chest;
        chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        
    }

    private void Update()
    {
        Debug.Log(istrig);
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(istrig)
            {
                Open();
                
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            istrig  = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            istrig = false;
        }
    }

    void Open()
    {
        chestAnim.SetTrigger("open");
        opened = true;
    }

}
