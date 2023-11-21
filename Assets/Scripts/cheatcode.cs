using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatcode : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gamesave.clearStage);
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F1))
        {
            if(gamesave.clearStage <1)
                gamesave.clearStage = 1;
            
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F2))
        {
            if (gamesave.clearStage < 2)
                gamesave.clearStage = 2;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F3))
        {
            if (gamesave.clearStage < 3)
                gamesave.clearStage = 3;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F4))
        {
            if (gamesave.clearStage < 4)
                gamesave.clearStage = 4;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F5))
        {
            if (gamesave.clearStage < 5)
                gamesave.clearStage = 5;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F6))
        {
            if (gamesave.clearStage < 6)
                gamesave.clearStage = 6;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F7))
        {
            if (gamesave.clearStage < 7)
                gamesave.clearStage = 7;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F8))
        {
            if (gamesave.clearStage < 8)
                gamesave.clearStage = 8;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F9))
        {
            if (gamesave.clearStage < 9)
                gamesave.clearStage = 9;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F10))
        {
            if (gamesave.clearStage < 10)
                gamesave.clearStage = 10;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F11))
        {
            if (gamesave.clearStage < 11)
                gamesave.clearStage = 11;
            PlayerPrefs.SetInt("Stage", gamesave.clearStage);
            PlayerPrefs.SetInt("Cine", 1);
            PlayerPrefs.Save();
        }
    }
}
