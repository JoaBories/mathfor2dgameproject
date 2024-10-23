using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingLogoSCript : MonoBehaviour
{
    Vector2 screenSize;
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

        Vector2 pos = GetComponent<RectTransform>().position;

        if (pos.x >= screenSize.x)
        {
            speed.x = -speed.x;
        }


        Debug.Log(screenSize.x + " " + transform.position);
    }
}
