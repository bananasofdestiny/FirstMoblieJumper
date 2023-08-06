using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObs : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject firePoint;

    public float spawnInterval = 0.9f;
    private float timer = 0.0f;

    private void Start()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // Reset the timer and execute the code
            timer = 0.0f;
            Instantiate(bullet,firePoint.transform.position,Quaternion.identity);
        }
    }
}
