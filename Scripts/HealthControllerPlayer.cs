using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerPlayer : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject healthBarObj;
    public GameObject GameOver;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //Death
        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            
            //kill gobbo
            foreach (GameObject spawn in Spawner.list)
            {
                if (spawn.GetComponent<HealthController>().IsDead == false)
                {
                    spawn.GetComponent<HealthController>().Die();
                }
            }
            // Disable
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Spells>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            healthBarObj.SetActive(false);
            animator.SetBool("IsDead", true);
            
            // Game Over Screen
            StartCoroutine(Gameover());
            
            
        }
        IEnumerator Gameover()
        {
            // Wait for Death Animation
            yield return new WaitForSeconds(0.8f);
            GameOver.SetActive(true);
            Time.timeScale = 0;
            this.enabled = false;
        }
    }
}
