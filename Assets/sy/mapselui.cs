using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapselui : MonoBehaviour
{
    public Button bt1;
    public Button bt2;
    public GameObject i;
    private bool isReady =true;
    // Start is called before the first frame update
    void Start()
    {
        if (gamesave.cine == -1)
            Invoke("wait", 12f);
        else
            Invoke("wait", 1f);
        i.SetActive(false);
        bt1.onClick.AddListener(Yes);
        bt2.onClick.AddListener(No);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady && Input.GetKeyDown(KeyCode.Escape))
        {
            i.SetActive(!i.activeSelf);
        }
    }
    void wait()
    {

        isReady = false;
    }
    void Yes()
    {
        uifade.isStart = true;
        isReady = true;
        Invoke("Exit", 1f);
    }
    void No()
    {
        i.SetActive(false);
    }
    void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
