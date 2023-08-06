using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public GameObject player;


    private int highestDistance = 0;
    private int distanceTraveled = 0;

    private void Update()
    {
        if (player.gameObject != null) 
        {

            float distanceMoved = Mathf.Abs(player.transform.position.y + 2f);
            distanceTraveled = (int)distanceMoved;

            if (distanceTraveled > highestDistance)
            {
                highestDistance = distanceTraveled;
            }

            distanceText.text = "Score: " + highestDistance.ToString();
        }

    }
}
