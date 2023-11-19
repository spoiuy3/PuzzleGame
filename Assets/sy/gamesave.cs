using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesave : MonoBehaviour
{
    public static int clearStage = -1;

    private void Start()
    {
        GameSave();
    }
    public void GameSave()
    {
        
        PlayerPrefs.SetInt("Stage", clearStage);
    }

    
}
