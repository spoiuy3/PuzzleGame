using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;
    public bool opened;

	// Use this for initialization
	void Awake ()
    {
        //get the Animator component from the chest;
        chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        opened = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player")&&!opened&&Input.GetKeyDown(KeyCode.F))
        {
            Open();
        }
    }

    void Open()
    {
        chestAnim.SetTrigger("open");
        opened = true;
    }

}
