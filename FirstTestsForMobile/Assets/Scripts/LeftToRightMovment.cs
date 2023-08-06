using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightMovment : MonoBehaviour
{
    public float speed = 5.0f;
    public float constraintValue;
    public float constraintValueNegative;
    private bool moveRight = true;

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
    }

}
