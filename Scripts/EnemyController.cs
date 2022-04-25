using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public GameObject canvas;
    public Transform Detection;
    public float AggroRange = 500f;
    public Transform DamageRange;
    float damageRange = 0.8f;
    public Animator animator;
    public LayerMask playerLayer;
    public Vector2 target;
    Vector2 currentPos;
    public float moveSpeed = 1.7f;
    public float AttackSpeed = 0.5f;
    public float NextAttackTime = 0f;
    int damage = 1;
    public float APS = 10f;
    float nextAttack = 0f;
    public float stagger = 0;


    private void Update()
    {
        currentPos = transform.position;
        Collider2D[] detectedPlayers = Physics2D.OverlapCircleAll(Detection.position, AggroRange, playerLayer);

        foreach (Collider2D player in detectedPlayers)
        {
            target = player.transform.position;
        }

        //bevægelse
        if (Vector2.Distance(transform.position, target) >= 1)
        {
            if (stagger <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, (moveSpeed * Time.deltaTime));
            }

        }
        else
        {
            target = currentPos;
            if (Time.time >= NextAttackTime)
            {
                attack();
                NextAttackTime = Time.time + 1f / AttackSpeed;
            }
        }
        //animation
        if (target.x - currentPos.x > 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            canvas.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
        }
        else if (target.x - currentPos.x < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            canvas.transform.localScale = new Vector3(-0.004f, 0.004f, 0.004f);
        }
        if (currentPos == target)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }
    private void FixedUpdate()
    {
        Collider2D[] damagePlayer = Physics2D.OverlapCircleAll(DamageRange.position, damageRange, playerLayer);

        foreach (Collider2D player in damagePlayer)
        {
            if (Time.time >= nextAttack)
            {
                player.GetComponent<HealthControllerPlayer>().TakeDamage(damage);
                nextAttack = Time.time + 1f / APS;
            }
        }
        if (stagger! >= 0)
        {
            --stagger;
        }
        
    }
    void attack()
    {
        //animation
        animator.SetTrigger("attack");
        //damage
        
    }

    private void OnDrawGizmos()
    {
        if (Detection == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(Detection.position, AggroRange);
    }
}
