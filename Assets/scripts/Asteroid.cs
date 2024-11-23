using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    public List<float> speedList;
    public List<Sprite> spriteList;
    public float baseRadius;
    public List<float> scaleList;
    public int size; // 2 --> L, 1 --> M, 0 --> S
    private float speed;
    public float radius;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));

        speed = speedList[size];
        GetComponent<SpriteRenderer>().sprite = spriteList[size];
        transform.localScale = new Vector3(scaleList[size], scaleList[size], scaleList[size]);
        radius = baseRadius * transform.localScale.x;
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        float shipRadius = Spaceship.instance.shipRadius;
        if ((transform.position - Spaceship.instance.transform.position).magnitude <= shipRadius + radius)
        {
            Spaceship.instance.gameOver();
        }

        foreach (GameObject laser in GameObject.FindGameObjectsWithTag("laser"))
        {
            if ((laser.transform.position - transform.position).magnitude <= radius)
            {
                Destroy(laser);
                split(size);
            }
        }
    }

    private void split(int size)
    {
        if (size != 0)
        {
            GameObject currentAsteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            currentAsteroid.GetComponent<Asteroid>().size = size - 1;
            currentAsteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            currentAsteroid.GetComponent<Asteroid>().size = size - 1;
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
