using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector2 difference = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0,0, -Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg);
    }
}
