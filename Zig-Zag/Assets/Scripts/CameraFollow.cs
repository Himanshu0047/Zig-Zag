using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float lerpRate = 0;
    public GameObject ball;
    public bool gameOver;
    AudioSource music;

    void Start()
    {
        offset = ball.transform.position - transform.position;
        music = GetComponent<AudioSource>();
        music.Play();
    }

    void FixedUpdate()
    {
        if (gameOver == false)
        {
            Follow();
        }
        if(gameOver == true)
        {
            music.Stop();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
