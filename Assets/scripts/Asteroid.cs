using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
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
    }
}
