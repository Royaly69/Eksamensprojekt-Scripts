using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public GameObject timer;
    Vector2 playerPos;
    Vector2 randomDir;
    Vector2 spawnPos;
    public float spawnTime = 0;
    public float spawnSpeed;

    float spawnDistance = 15;
    float randomx;
    float randomy;

    public static List<GameObject> list = new List<GameObject>();
    
    void Update()
    {
        randomx = Random.Range(-1f, 1f);
        randomy = Random.Range(-1f, 1f);
        playerPos = Player.transform.position;
        randomDir = new Vector2 (randomx, randomy);
        spawnPos = playerPos + randomDir.normalized*spawnDistance;
        

        if (Time.time >= spawnTime)
        {
            GameObject spawn = Instantiate(Enemy);
            list.Add(spawn);
            spawn.transform.position = spawnPos;
            spawnTime = Time.time + 1f / spawnSpeed;
        }
    }
    private void FixedUpdate()
    {
        spawnSpeed = 1 + timer.GetComponent<Timer>().levelTime*0.01f;
    }
}
