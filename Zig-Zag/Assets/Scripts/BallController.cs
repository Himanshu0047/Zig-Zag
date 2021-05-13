using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float speed = 0;
    [SerializeField]
    float minHeight = -1f;
    Rigidbody rb;
    bool started = false;
    public GameObject particle;
    public static BallController instance;
    public bool gameOver;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(started == false)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                // Starts moving the ball.
                rb.velocity = new Vector3(0, 0, speed);
                started = true;
                GameManager.instance.StartGame();
            }
        }
        if(Input.GetMouseButtonDown(0) && gameOver == false)
        {
            // Change direction of the ball.
            SwitchDirection();
        }
        if(transform.position.y < minHeight)
        {
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameManager.instance.EndGame();
            PlatformSpawner.instance.gameOver = true;
            gameOver = true;
        }
        
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gem")
        {
            GameObject obj = Instantiate(particle, other.gameObject.transform.position, particle.transform.rotation) as GameObject;
            Destroy(obj, 1f);
            Destroy(other.gameObject);
        }
    }

}
