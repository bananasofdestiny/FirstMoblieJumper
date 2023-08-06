using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public float rotatingSpeed = 100f;
    void Update()
    {
        transform.Rotate(0f,0f,rotatingSpeed *  Time.deltaTime);
    }
}
