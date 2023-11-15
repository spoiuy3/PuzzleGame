using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSinteract : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log("Play"); // UI �ۼ� �ʿ� �κ�
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Quit"); // UI �ۼ� �ʿ� �κ�
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
}
