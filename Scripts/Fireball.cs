using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 9);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 enemyPos = collision.transform.position;
        collision.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        DamagePopup.Create(enemyPos, damage);
    }
}
