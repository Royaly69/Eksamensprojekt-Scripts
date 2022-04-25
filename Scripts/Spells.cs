using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    Vector2 Target;
    //public Texture2D AbilityIcon1;
    //public GameObject Ability1;
    public LayerMask enemyLayers;
    public Transform Ability1HitScan;
    public GameObject canvas;
    public Animator animator;
    Vector2 MousePos;
    Vector3 enemyPos;
    public int minDam = 40;
    public int maxDam = 60;
    public float Ability1AoE = 1.5f;
    public float AttackSpeed1 = 1.5f; 
    float nextAbility1 = 0f;
    public GameObject pfPlasmaBall;
    private GameObject PlasmaBall;
    public float AttackSpeed2 = 2;
    
    public float ProjSpeed = 4f;

    private int Talent1Tier;
    float nextTalent1 = 0f;

    private int Talent2Tier;
    public GameObject LemonAura;
    float nextTalent2Tick = 0;
    float LemonTickRate = 2;
    int LemonDamage = 2;

    private int Talent3Tier;
    public GameObject Boomerang1;
    public GameObject Boomerang2;
    public GameObject Boomerang3;


    void Update()
    {
        stats();
        animator.SetFloat("animSpeed", AttackSpeed1);
        MousePos = Input.mousePosition;
        Target = Camera.main.ScreenToWorldPoint(MousePos) - Camera.main.transform.position;
        
        Ability1HitScan.transform.position = new Vector2(transform.position.x, transform.position.y) + Target.normalized * 2;

        // Default Attack
        if (Time.time >= nextAbility1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                CastAbility1();
                nextAbility1 = Time.time + 1f/AttackSpeed1;
            }
        }
        // Talent 1 Plasma Ball
        if (Talent1Tier != 0)
        {
            if (Time.time >= nextTalent1)
            {
                CastPlasmaBall();
                nextTalent1 = Time.time + 1f / (AttackSpeed2/Talent1Tier);
            }
        }
        // Talent 2 Lemon Aura
        if (Talent2Tier != 0)
        {
            if (Time.time >= nextTalent2Tick)
            {
                lemonAura();
                nextTalent2Tick = Time.time + 1f / (LemonTickRate*Talent2Tier);
            }

        }
        // Talent 3 Boomerang Orbital
        if (Talent3Tier != 0)
        {
            Boomerang1.SetActive(true);
             if (Talent3Tier != 1)
             {
                if (Talent3Tier < 3)
                {
                    Boomerang2.SetActive(true);
                }
                else
                {
                    Boomerang3.SetActive(true);
                    Boomerang2.transform.position.Set(0.87f, -0.49f, 0);
                }
             }
            
        }
    }
    // Default Attack
    void CastAbility1()
    {
        int Ability1damage = Random.Range(minDam,maxDam);
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Ability1HitScan.position,Ability1AoE, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            int damage = Ability1damage; 
            enemyPos = enemy.transform.position;
            enemy.GetComponent<HealthController>().TakeDamage(damage);
            DamagePopup.Create(enemyPos, damage);
        }
        if (MousePos.x > Screen.width / 2)
        {
            transform.localScale = new Vector3(3f, 3f, 1.5f);
            canvas.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
        }
        else if (MousePos.x < Screen.width / 2)
        {
            transform.localScale = new Vector3(-3f, 3f, 1.0f);
            canvas.transform.localScale = new Vector3(-0.003f, 0.003f, 0.003f);
        }
        animator.SetTrigger("attack");
        Casting();
    }
    float randomx;
    float randomy;
    Vector2 randomTarget;

    // Talent 1 Plasma Ball
    void CastPlasmaBall()
    {
        randomx = Random.Range(-1f, 1f);
        randomy = Random.Range(-1f, 1f);
        randomTarget = new Vector2(randomx, randomy);
        int Ability2damage = Random.Range(minDam, maxDam);
        PlasmaBall = Instantiate(pfPlasmaBall);
        PlasmaBall.transform.position = transform.position;
        PlasmaBall.GetComponent<Direction>().dir = randomTarget.normalized;
        PlasmaBall.GetComponent<Direction>().playerPos = transform.position;
        PlasmaBall.GetComponent<Fireball>().damage = Ability2damage;
        PlasmaBall.transform.parent = null;
    }

    void lemonAura()
    {
        Vector2 size = new Vector2(8f, 4f);
        LemonAura.SetActive(true);
        Collider2D[] hitEnemies = Physics2D.OverlapCapsuleAll(LemonAura.transform.position, size, LemonAura.GetComponent<CapsuleCollider2D>().direction,transform.rotation.z,enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            int damage = LemonDamage;
            enemyPos = enemy.transform.position;
            enemy.GetComponent<HealthController>().TakeDamage(damage);
            DamagePopup.Create(enemyPos, damage);
        }
    }
    
    
    
    
    
    //disable movement while attacking
    void Casting()
    {
        float cooldown = 40 /AttackSpeed1;
        GetComponent<PlayerMovement>().target = transform.position;
        GetComponent<PlayerMovement>().casting = cooldown;
    }
    // draw default attack hitbox (testing)
    private void OnDrawGizmos()
    {
        if (Ability1HitScan == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(Ability1HitScan.position, Ability1AoE);
    }
    void stats()
    {
        AttackSpeed1 = GetComponent<StatSheet>().AttackSpeed1;
        AttackSpeed2 = GetComponent<StatSheet>().AttackSpeed2;
        ProjSpeed = GetComponent<StatSheet>().ProjSpeed;
        Talent1Tier = GetComponent<StatSheet>().Talent1Tier;
        Talent2Tier = GetComponent<StatSheet>().Talent2Tier;
        Talent3Tier = GetComponent<StatSheet>().Talent3Tier;
    }

}
