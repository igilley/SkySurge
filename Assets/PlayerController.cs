using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Fuel & Score")]
    public float maxFuel = 100f;
    public float currentFuel;
    public int score = 0;

    [Header("State")]
    public bool isAlive = true;

    [Header("Audio")]
    public AudioSource fuelPickupSound; // Assign in Inspector

    void Start()
    {
        currentFuel = maxFuel;

        // If AudioSource not assigned in Inspector, get it from this GameObject
        if (fuelPickupSound == null)
            fuelPickupSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isAlive) return;

        // Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(0, verticalInput, 0);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // Clamp Y position
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        // Fuel countdown
        currentFuel -= 5f * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);

        // Check for fuel depletion
        if (currentFuel <= 0f && isAlive)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAlive) return;

        if (collision.CompareTag("Fuel"))
        {
            // Increase fuel and score
            currentFuel += 20f;
            currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
            score += 10;

            // Play fuel pickup sound
            if (fuelPickupSound != null)
                fuelPickupSound.Play();

            // Destroy the fuel can
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        Debug.Log("Game Over! Score: " + score);
        SceneManager.LoadScene("GameOverScene"); // Make sure scene name matches exactly
    }
}
