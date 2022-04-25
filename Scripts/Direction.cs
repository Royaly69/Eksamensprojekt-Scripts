using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public Vector2 dir;
    public Vector2 target;
    public Vector2 currentPos;
    public Vector2 playerPos;
    int rotation;



    void Start()
    {
        target = dir * 10 + playerPos;
    }
    
    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if (currentPos == target)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, (player.GetComponent<Spells>().ProjSpeed * Time.deltaTime));
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        rotation += 2;
    }
}
