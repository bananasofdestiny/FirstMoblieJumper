using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float respawnTimer = 3.0f;
    public GameObject CameraParent;


    void Update()
    {
        if (player == null) return;
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }  

    }

}
