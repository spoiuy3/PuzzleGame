using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesave : MonoBehaviour
{
    public static int clearStage = -1;
    public static int cine = -1;
    public static int curStage = 0;

    private void Start()
    {
        GameSave();
    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("Cine", cine);
        PlayerPrefs.SetInt("Stage", clearStage);
        PlayerPrefs.SetInt("CurStage", curStage);
        PlayerPrefs.Save();
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
