﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;
    public bool opened;
    private bool onTrigger;

	// Use this for initialization
	void Awake ()
    {
        //get the Animator component from the chest;
        chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        opened = false;
        onTrigger = false;
    }

    private void Update()
    {
        Debug.Log(onTrigger);
        if(Input.GetKeyDown(KeyCode.K)&&!opened&&interact.state=="2d"&&onTrigger)
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
    }

}
