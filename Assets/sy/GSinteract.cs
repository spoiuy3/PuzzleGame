using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GSinteract : MonoBehaviour
{
    public AudioClip myAudioClip1; // Inspector에서 설정할 오디오 클립
    public AudioClip myAudioClip2;

    private AudioSource audioSource;
    public GameObject redFire;
    public GameObject redSmoke;
    public GameObject blueFire;
    public GameObject blueSmoke;
    private bool redout;
    private bool blueout;
    private ParticleSystem.MainModule redFire_;
    private ParticleSystem.MainModule redSmoke_;
    private ParticleSystem.MainModule blueSmoke_;
    private ParticleSystem.MainModule blueFire_;
    private bool redfirecollision;
    private bool bluefirecollision;
    public static bool isQuit =false;
    private bool uiopen = true;
    public Button bt1;
    public Button bt2;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // 오디오 클립 설정
        audioSource.clip = myAudioClip1;
        uiopen = true;
        ui.SetActive(false);
        bt1.onClick.AddListener(Yes);
        bt2.onClick.AddListener(No);
        isQuit = false;
        redout = true;
        blueout = true;
        redfirecollision = false;
        bluefirecollision = false;
        redFire_ = redFire.GetComponent<ParticleSystem>().main;
        redSmoke_ = redSmoke.GetComponent<ParticleSystem>().main;
        blueFire_ = blueFire.GetComponent<ParticleSystem>().main;
        blueSmoke_ = blueSmoke.GetComponent<ParticleSystem>().main;
    }

    // Update is called once per frame
    void Update()
    {
        if (redfirecollision)
        {
            redout = true;
            redFire.SetActive(true);
            redSmoke.SetActive(true);
            redFire_.loop = true;
            redSmoke_.loop = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(gamesave.clearStage == -1 && gamesave.cine == -1)
                {
                    uifade.isStart = true;
                    StartCoroutine(DelayedFunction3());
                }
                else
                {
                    uifade.isStart = true;
                    StartCoroutine(DelayedFunction4());
                }
            }
        }
        else if (!redfirecollision&&redout)
        {
            redFire_.loop = false;
            redSmoke_.loop = false;
            StartCoroutine(DelayedFunction1());
            redout = false;
        }
        if (bluefirecollision)
        {
            blueout = true;
            blueFire.SetActive(true);
            blueSmoke.SetActive(true);
            blueFire_.loop = true;
            blueSmoke_.loop = true;
            if (Input.GetKeyDown(KeyCode.F)&&uiopen)
            {
                audioSource.Play();
                ui.SetActive(true);
                movescript1.canMove = false;
            }
        }
        else if(!bluefirecollision&&blueout)
        {
            blueFire_.loop = false;
            blueSmoke_.loop = false;
            StartCoroutine(DelayedFunction2());
            blueout = false;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Fire2_5on"))
        {
            redfirecollision = true;
        }
        else if (collider.gameObject.CompareTag("Fire2_on"))
        {
            bluefirecollision = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Fire2_5on"))
        {
            redfirecollision = false;
        }
        else if (collider.gameObject.CompareTag("Fire2_on"))
        {
            bluefirecollision = false;
        }
    }
    IEnumerator DelayedFunction1()
    {
        yield return new WaitForSeconds(2.0f);
        redFire.SetActive(false);
        redSmoke.SetActive(false);
    }
    IEnumerator DelayedFunction2()
    {

        yield return new WaitForSeconds(2.0f);
        blueFire.SetActive(false);
        blueSmoke.SetActive(false);
    }
    IEnumerator DelayedFunction3()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Begin_Story");
    }
    IEnumerator DelayedFunction4()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MapSelect");
    }
    void DelayedFunction5()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    void Yes()
    {
        audioSource.clip = myAudioClip2;
        audioSource.Play();
        uifade.isStart = true;
        uiopen = false;
        ui.SetActive(false );
        Invoke("DelayedFunction5", 1.0f);
    }

    void No()
    {
        movescript1.canMove = true;
        ui.SetActive(false);
    }
}
