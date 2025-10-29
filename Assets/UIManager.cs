using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Player & Stats")]
    public PlayerController playerController;
    public Slider fuelSlider;
    public Text fuelText;
    public Text scoreText;
    public Text survivalTimeText; // Timer shown during gameplay

    [Header("UI Elements")]
    public Button restartButton; // Used on GameOver scene

    private float survivalTime = 0f;
    private bool isPlayerAlive = true;

    void Start()
    {
        // Auto-find player
        if (playerController == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                playerController = player.GetComponent<PlayerController>();
        }

        // Initialize fuel slider
        if (fuelSlider != null && playerController != null)
        {
            fuelSlider.maxValue = playerController.maxFuel;
            fuelSlider.value = playerController.currentFuel;
        }

        UpdateUI();

        // Set up restart button if present (used on GameOver scene)
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (playerController == null) return;

        if (playerController.isAlive)
        {
            // Update survival timer
            survivalTime += Time.deltaTime;
            if (survivalTimeText != null)
                survivalTimeText.text = "Time: " + Mathf.FloorToInt(survivalTime) + "s";

            // Update fuel slider
            if (fuelSlider != null)
                fuelSlider.value = playerController.currentFuel;

            UpdateUI();
        }
        else
        {
            if (isPlayerAlive) // first frame death
            {
                isPlayerAlive = false;

                // Save survival time to GameManager
                if (GameManager.instance != null)
                    GameManager.instance.survivalTime = survivalTime;

                // Load GameOver scene
                SceneManager.LoadScene("GameOverScene"); // make sure scene is added in Build Settings
            }
        }
    }

    void UpdateUI()
    {
        if (fuelText != null)
            fuelText.text = $"{playerController.currentFuel:F0}/{playerController.maxFuel:F0}";

        if (scoreText != null)
            scoreText.text = $"Score: {playerController.score}";
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // restart main game
    }
}
