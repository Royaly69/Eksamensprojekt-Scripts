using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 target;
    public Animator animator;
    public Vector2 CurrentPos;
    Vector2 MousePos;
    public float casting = 0;
    
    public GameObject canvas;
    
    void Update()
    {
        CurrentPos = transform.position;
        MousePos = Input.mousePosition;
        

        if (Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (MousePos.x > Screen.width / 2)
            {
                transform.localScale = new Vector3(3f, 3f, 1.0f);
                canvas.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            }
            else if (MousePos.x < Screen.width / 2)
            {
                transform.localScale = new Vector3(-3f, 3f, 1.0f);
                canvas.transform.localScale = new Vector3(-0.003f, 0.003f, 0.003f);
            }
            if (CurrentPos == target)
            {
                animator.SetBool("IsMoving", false);
            }
            else
            {
                animator.SetBool("IsMoving", true);
            }
        }

        if (casting <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, (moveSpeed * Time.deltaTime));
        }
        // Animation
        if (CurrentPos == target)
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void FixedUpdate()
    { 
    if(casting !>= 0)
    {
        --casting;
    }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if (collision.collider.CompareTag("Wall"))
        {
            target = transform.position;
        }
    }
}
