using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laseBeam : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if ((startPos - transform.position).magnitude > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
