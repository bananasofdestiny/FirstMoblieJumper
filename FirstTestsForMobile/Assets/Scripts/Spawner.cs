using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public Transform spawnPoint;
    public GameManager manager;

    public float yOffset = 3.0f;
    public float spawnInterval = 0.9f;
    private float timer = 0.0f;
    private Vector3 lastSpawnPosition = Vector3.zero;


    private static List<GameObject> spawnedObstacles = new List<GameObject>();

    void Start()
    {
        InitializeObstacles();
    }

    public void InitializeObstacles()
    {
        // Initialize 2 obstacles at start
        for (int i = 0; i < 2; i++)
        {
            SpawnObstacle();
            
        }
    }
    private void Update()
    {
        if (manager.gameStarted)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                // Reset the timer and execute the code
                timer = 0.0f;
                SpawnObstacle();
            }
            if (spawnedObstacles.Count > 40)
            {
                DestroyObsacles();
            }
        }


    }
    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstacles[UnityEngine.Random.Range(0, obstacles.Count)];
        float obstacleXPosition = obstacleToSpawn.transform.position.x;
        float obstacleZRotation = obstacleToSpawn.transform.rotation.eulerAngles.z;
        Vector3 spawnPosition = new Vector3(obstacleXPosition, yOffset + lastSpawnPosition.y, 0f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, obstacleZRotation);
        GameObject obstacle = Instantiate(obstacleToSpawn, spawnPosition, spawnRotation);
        lastSpawnPosition = spawnPosition;
        spawnedObstacles.Add(obstacle);
    }

    public void DestroyObsacles()
    {
        GameObject obstacleToRemove = spawnedObstacles[0];
        spawnedObstacles.RemoveAt(0);
        Destroy(obstacleToRemove);  
    }

}
