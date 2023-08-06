using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject backgroundPrefab; // Reference to the background prefab
    public float parallaxScale = 0.5f;  // The amount of parallax effect (0 to 1)
    public float offsetY = 10f;        // Offset to spawn new backgrounds

    private Transform cam;            // Reference to the main camera transform
    private List<GameObject> backgrounds = new List<GameObject>();
    private Vector3 previousCamPos;   // The position of the camera in the previous frame

    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;

        SpawnBackground();
    }

    void Update()
    {
        // Calculate the parallax effect based on the camera's movement
        float parallax = (previousCamPos.y - cam.position.y) * parallaxScale;

        // Move each background towards the target position using Lerp
        foreach (var background in backgrounds)
        {
            Vector3 backgroundTargetPos = new Vector3(background.transform.position.x, background.transform.position.y + parallax, background.transform.position.z);
            background.transform.position = Vector3.Lerp(background.transform.position, backgroundTargetPos, Time.deltaTime);
        }

        // Update the previous camera position
        previousCamPos = cam.position;

        // Check if we need to spawn a new background
        if (cam.position.y >= backgrounds[backgrounds.Count - 1].transform.position.y - offsetY)
        {
            SpawnBackground();
        }

        // Check if we need to remove the oldest background
        if (cam.position.y >= backgrounds[0].transform.position.y + offsetY)
        {
            Destroy(backgrounds[0]);
            backgrounds.RemoveAt(0);
        }
    }

    void SpawnBackground()
    {
        Vector3 spawnPosition = backgrounds.Count == 0 ? transform.position : backgrounds[backgrounds.Count - 1].transform.position + Vector3.up * offsetY;
        GameObject newBackground = Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
        backgrounds.Add(newBackground);
    }
}
