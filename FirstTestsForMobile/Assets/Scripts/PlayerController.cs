using System;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public ParticleSystem deathEffect;
    public GameObject endPanel;
    public EndMenu endMenu;
    private PauseMenu pauseMenu;
    public float rotationSpeed = 30f; 

    public Rigidbody2D rb;
    [SerializeField] private Camera cam;
    //[SerializeField] private float respawnTimer = 3.0f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource jumpEffect;
    [SerializeField] private AudioSource soundDeath;
    public bool playerDied = false;
    public bool imortality = false;
    public bool hasStartedRotating = false;

    private void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
    }
    void Update()
    {
        float cameraBottomY = cam.transform.position.y;
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Jump")|| Input.touchCount > 0)
            {
                Jump();
                hasStartedRotating = true;

                
            }
            if (transform.position.y < -5f || transform.position.y > cameraBottomY)
            {
                transform.position = new Vector3(transform.position.x, -4.9f, transform.position.z);
                CallPlayerDied();
            }
        }
        

    }

    private void Jump()
    {
        jumpEffect.Play();
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpForce));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacles") && !imortality )
        {
            //show high score
            if (gameManager != null)
            {
                soundDeath.Play();
                CallPlayerDied();

            }
        }
    }
    private void FixedUpdate()
    {
        if (hasStartedRotating)
        {
            RotateInCircle();
        }
    }

    private void RotateInCircle()
    {
        // Rotate the object in a circle around its own z-axis (up-axis)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void CallPlayerDied()
    {
        
        playerDied = true;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(gameObject);
        endPanel.SetActive(true);
        //EndMenu.StartGrowingEffect(endPanel.transform); // invoked??
        endMenu.InvokeThis(endPanel.transform);
    }

}
