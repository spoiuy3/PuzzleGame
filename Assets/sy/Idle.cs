using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class Idle : MonoBehaviour
{
    private float scaleSpeed = 0.008f;
    private Vector3 currentScale;
    private bool getSmall;
    private Vector3 moveVec;

    void Start()
    {
        currentScale = transform.localScale;
        getSmall = true;
    }


    void Update()
    {
        moveVec = movescript1.movement;
        if (getSmall && currentScale.y > 2.7f && moveVec.magnitude < 0.01f)
        {
            currentScale.y -= scaleSpeed;
            transform.localScale = currentScale;
        }
        else if (!getSmall && 3.0f > currentScale.y && moveVec.magnitude < 0.01f)
        {
            currentScale.y += scaleSpeed;
            transform.localScale = currentScale;
        }
        if (2.6f < currentScale.y && currentScale.y < 2.7f)
            getSmall = false;
        else if (currentScale.y == 3.0f)
            getSmall = true;
    }

};
