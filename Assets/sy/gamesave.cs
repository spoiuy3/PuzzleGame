using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesave : MonoBehaviour
{
    public static int clearStage = -1;
    public static int cine = -1;

    private void Start()
    {
        GameSave();
    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("Cine", cine);
        PlayerPrefs.SetInt("Stage", clearStage);
    }

    
}
