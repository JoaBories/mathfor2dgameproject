using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private Vector3 velocity;
    private float speed;
    private Vector3 goalPosition;
    public float shipRadius;
    [SerializeField] private GameObject lasePrefab;
    public static Spaceship instance;
    private float nextShoot;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject restartButton;


    private void Start()
    {
        goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        instance = this;
        nextShoot = Time.time;
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
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && nextShoot < Time.time)
        {
            Instantiate(lasePrefab, transform.position, transform.rotation);
            nextShoot = Time.time + 0.2f;
        }

        velocity += transform.up * speed * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (GameObject.FindGameObjectsWithTag("Asteroid").Count() == 0)
        {
            win();
        }
        
    }

    public void gameOver()
    {
        endText.SetActive(true);
        endText.GetComponent<Text>().text = "loose";
        restartButton.SetActive(true);
        Destroy(gameObject);
    }

    public void win()
    {
        endText.SetActive(true);
        endText.GetComponent<Text>().text = "win";
        restartButton.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shipRadius);
    }
}
