using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float survivalTime = 0f;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // survives scene loads
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }
}
