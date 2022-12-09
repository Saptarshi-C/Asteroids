using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.EventSystems;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Sprite asteroidSprite0;
    [SerializeField]
    private Sprite asteroidSprite1;
    [SerializeField]
    private Sprite asteroidSprite2;
    private const float MinMoveSpeed = 1;
    private const float MaxMoveSpeed = 3;
    private Rigidbody2D asteroidRb;
    private SpriteRenderer asteroidSr;
    // Start is called before the first frame update
    void Start()
    {
        asteroidSr = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if(spriteNumber == 0)
        {
            asteroidSr.sprite = asteroidSprite0;
        }
        else if (spriteNumber == 1)
        {
            asteroidSr.sprite = asteroidSprite1;
        }
        else
        {
            asteroidSr.sprite = asteroidSprite2;
        }
    }

    public void Initialize(Direction direction, Vector3 location)
    {        
        float angle = (Random.Range(0f, 30f) + (int)direction)*Mathf.Deg2Rad;        
        StartMoving(angle);
        transform.position = location;
    }

    void StartMoving(float angle)
    {
        float moveSpeed = Random.Range(MinMoveSpeed, MaxMoveSpeed);
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        asteroidRb = GetComponent<Rigidbody2D>();
        asteroidRb.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(collision.gameObject);
            if (transform.localScale.x > 0.5)
            {
                transform.localScale /= 2;
                CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
                collider.radius /= 2;
                GameObject asteroid1 = Instantiate(gameObject);
                float angle1 = Random.Range(0, 2 * Mathf.PI);
                asteroid1.GetComponent<Asteroid>().StartMoving(angle1);
                GameObject asteroid2 = Instantiate(gameObject);
                float angle2 = Random.Range(0, 2 * Mathf.PI);
                asteroid2.GetComponent<Asteroid>().StartMoving(angle2);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
