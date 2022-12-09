using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab;

    private float colliderRadius;

    // Start is called before the first frame update
    void Start()
    {
        colliderRadius = asteroidPrefab.GetComponent<CircleCollider2D>().radius;

        // right of screen
        Vector3 position = new Vector3(ScreenUtils.ScreenRight + colliderRadius, 0 , 0);
        GameObject asteroid = Instantiate(asteroidPrefab);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Left, position);

        // left of screen
        position = new Vector3(ScreenUtils.ScreenLeft - colliderRadius, 0, 0);
        asteroid = Instantiate(asteroidPrefab);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Right, position);

        // Top of screen
        position = new Vector3(0, ScreenUtils.ScreenTop + colliderRadius, 0);
        asteroid = Instantiate(asteroidPrefab);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Down, position);

        // right of screen
        position = new Vector3(0, ScreenUtils.ScreenBottom - colliderRadius, 0);
        asteroid = Instantiate(asteroidPrefab);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Up, position);

    }
}
