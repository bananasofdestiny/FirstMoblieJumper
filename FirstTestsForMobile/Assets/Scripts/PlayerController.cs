using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public ParticleSystem deathEffect;

    private PauseMenu pauseMenu;
    public float rotationSpeed = 30f; 

    public Rigidbody2D rb;
    [SerializeField]
    private float respawnTimer = 3.0f;
    [SerializeField]
    private GameManager gameManager;
    public bool playerDied = false;
    public bool imortality = false;
    public bool hasStartedRotating = false;

    private void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
    }
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Jump"))
            {
                hasStartedRotating = true;

                Jump();
            }
            if (transform.position.y < -5f)
            {
                transform.position = new Vector3(transform.position.x, -4.9f, transform.position.z);
            }
        }

    }

    private void Jump()
    {
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
                playerDied = true;
                Instantiate(deathEffect,transform.position, Quaternion.identity);
                Destroy(gameObject);
                gameManager.Invoke("RestartGame", respawnTimer);
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

    
}
