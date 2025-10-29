using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with your main game scene name
    }
}
