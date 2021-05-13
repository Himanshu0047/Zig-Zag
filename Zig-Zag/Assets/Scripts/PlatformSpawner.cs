using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    Vector3 lastPos;
    Vector3 pos;
    public GameObject platform;
    public GameObject gem;
    float size;
    public static PlatformSpawner instance;
    public bool gameOver;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for(int i = 0; i<10; i++)
        {
            SpawnPlatforms();
        }

    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

    void Update()
    {
 
        if (gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnX()
    {
        pos = lastPos;
        pos.x += size;
        Instantiate(platform, pos, platform.transform.rotation);
        lastPos = pos;
        int random = Random.Range(0, 8);
        if(random < 1)
        {
            Instantiate(gem, new Vector3(pos.x, pos.y + 1, pos.z), gem.transform.rotation);
        }
    }

    void SpawnZ()
    {
        pos = lastPos;
        pos.z += size;
        Instantiate(platform, pos, platform.transform.rotation);
        lastPos = pos;
        int random = Random.Range(0, 8);
        if (random < 1)
        {
            Instantiate(gem, new Vector3(pos.x, pos.y + 1, pos.z), gem.transform.rotation);
        }
    }

    void SpawnPlatforms()
    {
        int random = Random.Range(0, 6);
        if(random < 3)
        {
            SpawnX();
        }
        if(random >= 3)
        {
            SpawnZ();
        }
    }

}
