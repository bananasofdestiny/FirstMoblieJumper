using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehvior : MonoBehaviour
{
    public float bulletSpeed = 2f;
    public float rotationSpeed = 320f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-bulletSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -2.8f)
        {
            Destroy(gameObject);
        }
        RotateInCircle();
    }

    private void RotateInCircle()
    {
        // Rotate the object in a circle around its own z-axis (up-axis)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
