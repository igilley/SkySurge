using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text survivalTimeText; // assign in Inspector

    void Start()
    {
        if (survivalTimeText == null)
        {
            Debug.LogError("SurvivalTimeText UI not assigned in the Inspector!");
            return;
        }

        if (GameManager.instance != null)
        {
            // Get the saved survival time from GameManager
            float time = GameManager.instance.survivalTime;
            
            // Display it next to "Time Survived:"
            survivalTimeText.text = "Time Survived: " + Mathf.FloorToInt(time) + "s";

            Debug.Log("Survival time displayed on GameOver scene: " + time + "s");
        }
        else
        {
            // If GameManager instance is missing
            survivalTimeText.text = "Time Survived: 0s";
            Debug.LogWarning("GameManager instance not found! Survival time is 0.");
        }
    }
}
