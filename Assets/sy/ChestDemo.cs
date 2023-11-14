using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;
    public bool opened;
    private bool onTrigger;
    public bool haveKey = false;
    
    public bool HaveKey()
    {
        return haveKey;
    }
	// Use this for initialization
	void Awake ()
    {
        haveKey = false;
        //get the Animator component from the chest;
        chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        opened = false;
        onTrigger = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&!opened&&interact.state=="2d"&&onTrigger)
        {
            Open();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }

    void Open()
    {
        chestAnim.SetTrigger("open");
        opened = true;
        haveKey = true;
    }

}
