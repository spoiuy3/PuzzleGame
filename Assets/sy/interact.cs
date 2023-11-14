using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class interact : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject script;
    public static string state = "2d";
    public static bool redfirecollision = false;
    public static bool bluefirecollision = false;
    public static bool haveKey = false;
    Rigidbody rb;
    public GameObject[] redFire;
    public GameObject[] redSmoke;
    public GameObject[] blueFire;
    public GameObject[] blueSmoke;
    public GameObject[] chest;

    public bool KeyCheck()
    {
        foreach (GameObject elem in chest)
        {
            if (!elem.GetComponent<ChestDemo>().haveKey)
            {
                return false;
            }
        }
        return true;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        haveKey = KeyCheck();
        if (state == "2d")
        {
            foreach (GameObject elem in redFire)
            {
                elem.SetActive(false);
            }
            foreach (GameObject elem in redSmoke)
            {
                elem.SetActive(false);
            }
            foreach (GameObject elem in blueFire)
            {
                elem.SetActive(true); 
            }
            foreach (GameObject elem in blueSmoke)
            {
                elem.SetActive(true);
            }
            
        }
        if(state == "2_5d")
        {
            foreach (GameObject elem in redFire)
            {
                elem.SetActive(true);
            }
            foreach (GameObject elem in redSmoke)
            {
                elem.SetActive(true);
            }
            foreach (GameObject elem in blueFire)
            {
                elem.SetActive(false);
            }
            foreach (GameObject elem in blueSmoke)
            {
                elem.SetActive(false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (redfirecollision && state == "2d")
            {
                movescript1.canMove = false;
                script.GetComponent<ChangeCamera>().SwitchCamera();
                rb.velocity = Vector3.zero;
                state = "2_5d";

            }
            if(bluefirecollision && state == "2_5d")
            {
                movescript1.canMove = false;
                script.GetComponent<ChangeCamera>().SwitchCamera();
                rb.velocity = Vector3.zero;
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
