using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingLogoSCript : MonoBehaviour
{
    Vector2 screenSize;
    Vector2 screenPos;
    Vector2 dvdSize;
    public Vector2 speed;


    // Start is called before the first frame update
    void Start()
    {
        screenSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta;
        dvdSize = GetComponent<RectTransform>().sizeDelta;
        Debug.Log(screenSize+" "+dvdSize);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed.x, speed.y, 0) * Time.deltaTime;

        Vector2 pos = GetComponent<RectTransform>().localPosition;

        if (pos.x + dvdSize.x/2 >= screenSize.x/2 || pos.x - dvdSize.x / 2 <= -screenSize.x / 2)
        {
            speed.x = -speed.x;
        }

        if (pos.y + dvdSize.y/2 >= screenSize.y / 2 || pos.y - dvdSize.y / 2 <= -screenSize.y / 2)
        {
            speed.y = -speed.y;
        }
    }
}
