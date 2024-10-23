using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        float adj = player.transform.position.x - transform.position.x;
        float opp = player.transform.position.y - transform.position.y;
        Debug.Log(Mathf.Atan2(adj, opp) * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Euler(0,0, -Mathf.Atan2(adj, opp) * Mathf.Rad2Deg);
    }
}
