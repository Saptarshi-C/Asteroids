using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the bullet object
/// </summary>
public class Bullet : MonoBehaviour
{
    const float deathDelay = 4.0f;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = deathDelay;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Applies a force in a direction
    /// </summary>
    /// <param name="direction">Direction to move at</param>
    public void ApplyForce(Vector2 direction)
    {
        const float magnitude = 3.0f;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(magnitude*direction, ForceMode2D.Impulse);
    }
}
