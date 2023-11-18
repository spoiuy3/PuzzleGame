using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesave : MonoBehaviour
{
    string currentStage;

    private void Start()
    {
        GameLoad();
    }
    public void GameSave()
    {
        
        PlayerPrefs.SetString("Stage", SceneManager.GetActiveScene().name);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Stage"))
            return;
        currentStage = PlayerPrefs.GetString("Stage");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
