using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    Vector3 enemyPos;
    int BoomerangDam = 60;
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.layer == 6)
        {
            int damage = BoomerangDam;
            enemy.gameObject.GetComponent<HealthController>().TakeDamage(damage);
            enemyPos = enemy.transform.position;
            DamagePopup.Create(enemyPos, damage);
        }
    }


    float Rotate = 0;
    void FixedUpdate()
    {
        Rotate += 2;
        transform.localRotation = Quaternion.Euler(0, 0, Rotate);
    }
}
