using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float speed = 2f;                // Scroll speed
    public float resetPositionX = -30f;     // X position where object resets
    public float startPositionX = 30f;      // X position to move back to

    void Update()
    {
        // Move left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Loop back when off-screen
        if (transform.position.x <= resetPositionX)
        {
            Vector3 newPos = new Vector3(startPositionX, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
