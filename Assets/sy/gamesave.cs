using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesave : MonoBehaviour
{
    public static int clearStage = -1;

    private void Start()
    {
        
    }
    public void GameSave()
    {
        
        PlayerPrefs.SetInt("Stage", clearStage);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Stage"))
            return;
        clearStage = PlayerPrefs.GetInt("Stage");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
