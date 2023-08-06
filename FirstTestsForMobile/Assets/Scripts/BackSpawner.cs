using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSpawner : MonoBehaviour
{
    public GameObject background;
    public GameObject currBackground;
    public GameObject currForeGround;
    public GameObject forground;

    public Camera mainCamera;

    public int maxBackgrounds = 3;
    private List<GameObject> backgrounds = new List<GameObject>();
    private List<GameObject> foregrounds = new List<GameObject>();
    private GameObject oldBackground;
    private GameObject oldForeground;

    public float offsetY;
    public float parallaxSpeed = 0.5f;
    public float smoothing = 1f;


    void Start()
    {
        oldBackground = currBackground;
        oldForeground = currForeGround;
        backgrounds.Add(oldBackground);
        foregrounds.Add(oldForeground);
    }

    void Update()
    {
        if (backgrounds.Count == maxBackgrounds)
        {
            GameObject oldestBackground = backgrounds[0];
            backgrounds.RemoveAt(0);
            Destroy(oldestBackground);
        }
        if (foregrounds.Count == maxBackgrounds)
        {
            GameObject oldestBackground = foregrounds[0];
            foregrounds.RemoveAt(0);
            Destroy(oldestBackground);
        }

        if (mainCamera.transform.position.y >= currForeGround.transform.position.y - offsetY)
        {
            oldForeground = currForeGround;
            float backHeight = oldForeground.GetComponent<Renderer>().bounds.size.y;
            Vector3 spawnPosition = oldForeground.transform.position + Vector3.up * backHeight;

            currForeGround = Instantiate(forground, spawnPosition, Quaternion.identity);
            foregrounds.Add(currForeGround);


        }
        if (mainCamera.transform.position.y >= currBackground.transform.position.y - offsetY)
        {
            oldBackground = currBackground;
            float backHeight = oldBackground.GetComponent<Renderer>().bounds.size.y;
            Vector3 spawnPosition = oldBackground.transform.position + Vector3.up * backHeight;

            currBackground = Instantiate(background, spawnPosition, Quaternion.identity);
            backgrounds.Add(currBackground);


        }
        // Move only the background vertically based on camera movement for the parallax effect
        foreach (var background in backgrounds)
        {
            Vector3 targetPos = new Vector3(background.transform.position.x, background.transform.position.y - Time.deltaTime * parallaxSpeed, background.transform.position.z);
            background.transform.position = Vector3.Lerp(background.transform.position, targetPos, smoothing * Time.deltaTime);
        }
    }


}
