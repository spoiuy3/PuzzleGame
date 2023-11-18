using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_MS : MonoBehaviour
{
    private float scaleSpeed = 0.01f;
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
        if (getSmall && currentScale.y > 5.0f)
        {
            currentScale.y -= scaleSpeed;
            transform.localScale = currentScale;
        }
        else if (!getSmall && 6.0f > currentScale.y)
        {
            currentScale.y += scaleSpeed;
            transform.localScale = currentScale;
        }
        if (4.9f < currentScale.y && currentScale.y < 5.0f)
            getSmall = false;
        else if (currentScale.y == 6.0f)
            getSmall = true;
    }
}
