using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Mentions")]
    [SerializeField]
    private Rigidbody2D player;
    private PlayerController playerController;
    public Spawner spawner;
    public TextMeshProUGUI pressToStartText;

    private Coroutine scalingCoroutine;


    public bool gameOver = false;
    public bool gamePaused = false;
    public bool gameStarted = false;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        if (player != null && pressToStartText != null)
        {
            // Disable the Rigidbody component.
            player.isKinematic = true;

            scalingCoroutine = StartCoroutine(ScalePressToStartText());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == null) return;
        if (gameOver == true)
        { 
            /*
            playerMovement.enabled = false;
            playerMovement.rb.simulated = false;
            playerScore.SetActive(false);
            playerSprite.enabled = false;
            tapToStartBtn.SetActive(false);
            gameOverUI.SetActive(true);
            deathParticle.SetActive(true);
            gameOver = false;

            // Save the high score if it's greater than the current high score
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetFloat("HighScore", highScore);
                highScoreText.text = "High Score: " + highScore.ToString("0");
            }
            */
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        Debug.Log("start");
        player.isKinematic = false;
        gameStarted = true;
        if (pressToStartText != null)
        {
            StopCoroutine(scalingCoroutine);
            pressToStartText.rectTransform.localScale = Vector3.one;
            pressToStartText.gameObject.SetActive(false);
        }

    }

    private System.Collections.IEnumerator ScalePressToStartText()
    {
        // Define the initial and target scales for the text.
        Vector3 initialScale = Vector3.one;
        Vector3 targetScale = Vector3.one * 1.1f;

        float duration = 1.0f;
        float elapsedTime = 0f;

        // Scale up the text gradually
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            pressToStartText.rectTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            yield return null;
        }

        // Scale down the text gradually
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            pressToStartText.rectTransform.localScale = Vector3.Lerp(targetScale, initialScale, t);

            yield return null;
        }

        // Loop the scaling animation
        StartCoroutine(ScalePressToStartText());
    }




}
