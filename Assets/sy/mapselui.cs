using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Invoke("temp", 0.1f);
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

        if (i.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void temp()
    {
        if (gamesave.cine == 0)
            Invoke("wait", 12f);
        else
            Invoke("wait", 1f);
    }
    void wait()
    {

        isReady = false;
    }
    void Yes()
    {
        i.SetActive (false);
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
        SceneManager.LoadScene("GameStart");
    }
}
