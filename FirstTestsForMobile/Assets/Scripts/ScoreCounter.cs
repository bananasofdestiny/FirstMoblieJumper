using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public GameObject player;


    public int highestDistance = 0;
    public int distanceTraveled = 0;
    private void Start()
    {
        highestDistance = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void Update()
    {
        if (player.gameObject != null) 
        {

            float distanceMoved = Mathf.Abs(player.transform.position.y + 2f);
            if (distanceMoved > distanceTraveled) distanceTraveled = (int)distanceMoved;

            if (distanceTraveled > highestDistance)
            {
                highestDistance = distanceTraveled;
                PlayerPrefs.SetInt("HighScore", highestDistance);
            }

            distanceText.text = "Score: " + distanceTraveled.ToString();
        }

    }
}
