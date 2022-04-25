using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public GameObject healthBarObj;
    public GameObject healthBarFill;
    public bool IsDead = false;
    public AudioSource audioSource;
    public GameObject timer;




    void Start()
    {
        maxHealth = timer.GetComponent<Timer>().maxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        if (IsDead == false)
        {
            
            audioSource.PlayDelayed(Random.Range(0f, 2000f) / 10000);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            animator.SetTrigger("Hurt");
            stagger();
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    void stagger()
    {
        float cooldown = 10;
        GetComponent<EnemyController>().target = transform.position;
        GetComponent<EnemyController>().stagger = cooldown;
    }
    public void Die()
    {
        this.gameObject.layer = default;
        GetComponent<DropHandler>().createDrop();
        animator.SetBool("IsDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyController>().enabled = false;
        healthBarObj.SetActive(false);
        healthBarFill.SetActive(false);
        IsDead = true;
        StartCoroutine(Corpse());
    }
    IEnumerator Corpse()
    {
        yield return new WaitForSeconds(10f);
        Spawner.list.Remove(this.gameObject);
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
    


}
