using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move object left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy if off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
