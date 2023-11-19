using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameload : MonoBehaviour
{

    
    private void Start()
    {
        GameLoad();
        
    }
    private void Update()
    {
        GameLoad();
        Debug.Log(gamesave.cine);
        Debug.Log(gamesave.clearStage);
        if (GSinteract.isQuit) 
            GameExit();
    }
    public static void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Stage"))
            PlayerPrefs.SetInt("Stage", -1);
        if (!PlayerPrefs.HasKey("Cine"))
            PlayerPrefs.SetInt("Cine", -1);
        gamesave.clearStage = PlayerPrefs.GetInt("Stage");
        gamesave.cine = PlayerPrefs.GetInt("Cine");
    }

    public static void GameExit()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    

    
}
