using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class startui : MonoBehaviour
{
    
    
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)&&Input.GetKey(KeyCode.R)) { 
            Initialize();
            Debug.Log("Initialized");
            
        }
    }
    
    void Initialize()
    {
        PlayerPrefs.SetInt("Cine", -1);
        PlayerPrefs.SetInt("Stage", -1);
        PlayerPrefs.SetInt("CurStage", 0);
        PlayerPrefs.SetInt("End", 0);
        PlayerPrefs.Save();
    }
}
