using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInScreen : MonoBehaviour
{
    private Vector2 screenSize;
    private Vector2 objectSize;

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        objectSize = GetComponent<SpriteRenderer>().bounds.size;
    }

    private void Update()
    {
        if (transform.position.x > screenSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2, transform.position.y, 0);
        }
        else if (transform.position.x < -screenSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2, transform.position.y, 0);
        }

        if (transform.position.y > screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2, 0);
        }
        else if (transform.position.y < -screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2, 0);
        }
    }
}
