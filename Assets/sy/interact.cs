using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject script;
    public static string state = "2d";
    public static bool redfirecollision = false;
    public static bool bluefirecollision = false;
    public GameObject redFire;
    public GameObject redSmoke;
    public GameObject blueFire;
    public GameObject blueSmoke;

    // Update is called once per frame
    void Update()
    {
        
        if(state == "2d")
        {
            blueFire.SetActive(true);
            blueSmoke.SetActive(true);
            redFire.SetActive(false);
            redSmoke.SetActive(false);
        }
        if(state == "2_5d")
        {
            blueFire.SetActive(false);
            blueSmoke.SetActive(false);
            redFire.SetActive(true);
            redSmoke.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (redfirecollision && state == "2d")
            {

                script.GetComponent<ChangeCamera>().SwitchCamera();
                state = "2_5d";

            }
            if(bluefirecollision && state == "2_5d")
            {
                script.GetComponent<ChangeCamera>().SwitchCamera();
                state = "2d";
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire2_5on") && Physics.gravity.y < 0)
        {
            redfirecollision = true;
        }
        if (other.gameObject.CompareTag("Fire2_on") && Physics.gravity.z > 0)
        {
            bluefirecollision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fire2_5on") )
        {
            redfirecollision = false;
        }
        if (other.gameObject.CompareTag("Fire2_on") )
        {
            bluefirecollision = false;
        }
    }


}
