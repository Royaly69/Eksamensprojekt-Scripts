using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject player;
    public Transform Detection;
    float detectionRange = 1.5f;
    public LayerMask playerLayer;
    public float moveSpeed = 1f;
    bool pickedUp = false;
    Vector2 target;
    Vector2 currentPos;

    float startTime;
   
    void Awake()
    {
        startTime = Time.time;
    }
    private void Start()
    {
        target = transform.position;
    }
    void Update()
    {
        currentPos = transform.position;
        Collider2D[] detectedPlayers = Physics2D.OverlapCircleAll(Detection.position, detectionRange, playerLayer);
        foreach (Collider2D player in detectedPlayers)
        {
            pickedUp = true;
            target = player.transform.position;
        }
        if (pickedUp)
        {
            detectionRange = 500;
            Accelerate();
        }
        transform.position = Vector2.MoveTowards(transform.position,target,(moveSpeed*Time.deltaTime) );

        if (startTime - Time.timeSinceLevelLoad >= 60)
        {
            Destroy(gameObject);
        }

    }

    void Accelerate()
    {
        moveSpeed += Time.deltaTime*2;
    }
    
}
