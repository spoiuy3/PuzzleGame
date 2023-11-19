using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameload : MonoBehaviour
{
    private void Update()
    {
        if (GSinteract.isQuit) 
            GameExit();
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Stage"))
            return;
        if (!PlayerPrefs.HasKey("Cine"))
            return;
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
