using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesave : MonoBehaviour
{
    public static int clearStage = -1;
    public static int cine = -1;
    public static int curStage = 0;
    public static int end = 0;

    private void Start()
    {
        Invoke("GameSave", 0.2f);
        
    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("Cine", cine);
        PlayerPrefs.SetInt("Stage", clearStage);
        PlayerPrefs.SetInt("CurStage", curStage);
        PlayerPrefs.SetInt("End", end);
        PlayerPrefs.Save();
    }

    
}
