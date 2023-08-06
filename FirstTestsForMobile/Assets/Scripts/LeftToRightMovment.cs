using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightMovment : MonoBehaviour
{
    public float speed = 5.0f;
    public float constraintValue;
    public float constraintValueNegative;
    public float rotationSpeed = 320f;

    private bool moveRight = true;
    public bool isBlade = false;


    void Update()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= constraintValue)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= constraintValueNegative)
            {
                moveRight = true;
            }
        }
        if (isBlade)
        {
            RotateInCircle();
        }
    }
    private void RotateInCircle()
    {
        // Rotate the object in a circle around its own z-axis (up-axis)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

}
