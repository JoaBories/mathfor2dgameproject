using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInScreen : MonoBehaviour
{
    private Vector2 screenSize;
    [SerializeField] private float objectSize;

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    private void Update()
    {
        if (transform.position.x > (screenSize.x / 2)+ objectSize)
        {
            transform.position = new Vector3((-screenSize.x / 2) - objectSize, transform.position.y, 0);
        }
        else if (transform.position.x < -(screenSize.x / 2) - objectSize)
        {
            transform.position = new Vector3((screenSize.x / 2) +objectSize, transform.position.y, 0);
        }

        if (transform.position.y > (screenSize.y / 2) + objectSize)
        {
            transform.position = new Vector3(transform.position.x, -(screenSize.y / 2) - objectSize, 0);
        }
        else if (transform.position.y < -(screenSize.y / 2) - objectSize)
        {
            transform.position = new Vector3(transform.position.x, (screenSize.y / 2) + objectSize, 0);
        }
    }
}
