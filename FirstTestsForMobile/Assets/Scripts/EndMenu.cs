using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(1.5f, 1.5f, 1f);
    public float growthSpeed = 2f;

    private Vector3 initialScale;
    private bool isGrowing = false;

    [Header("Mentions")]
    public ScoreCounter scoreCounter;
    public GameObject scoreDisable;
    public TextMeshProUGUI scoretxt;
    public TextMeshProUGUI highestScoreTxt;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (isGrowing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, growthSpeed * Time.deltaTime);
        }
        if (gameObject.activeSelf)
        {
            scoreDisable.SetActive(false);
            ShowScores();
        }
    }

    public static void StartGrowingEffect(Transform panelTransform)
    {
        EndMenu effect = panelTransform.GetComponent<EndMenu>();
        if (effect != null)
        {
            effect.isGrowing = true;
        }
    }
    public void InvokeThis(Transform panelTransform)
    {
        float delayInSeconds = 1f;
        StartCoroutine(DelayedStartGrowingEffectCoroutine(panelTransform, delayInSeconds));
    }

    private IEnumerator DelayedStartGrowingEffectCoroutine(Transform panelTransform, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Call the StartGrowingEffect method with the provided parameter after the delay
        StartGrowingEffect(panelTransform);
    }
    private void ShowScores()
    {
        scoretxt.text = "Score: " + scoreCounter.distanceTraveled.ToString();
        highestScoreTxt.text = "Record: " + scoreCounter.highestDistance.ToString();
    }

}
