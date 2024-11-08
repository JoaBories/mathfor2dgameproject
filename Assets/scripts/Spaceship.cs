using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private Vector3 velocity;
    private float speed;
    private Vector3 goalPosition;
    [SerializeField] private float shipRadius;

    private void Start()
    {
        goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        speed = 0;

        if(goalPosition != Camera.main.ScreenToWorldPoint(Input.mousePosition))
        {
            goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 difference = goalPosition - transform.position;
            transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            speed = acceleration;
        }
        
        velocity += transform.up * speed * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        foreach(GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            float asteroidRadius = asteroid.GetComponent<Asteroid>().radius;
            if ((asteroid.transform.position - transform.position).sqrMagnitude <= (asteroidRadius + shipRadius) * (asteroidRadius + shipRadius))
            {
                gameOver();
            }
        }
        
    }

    private void gameOver()
    {
        Debug.Log("gameOver");
    }
}
