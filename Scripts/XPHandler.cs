using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XPHandler : MonoBehaviour
{
    //XP
    public int Level=1;
    int CurrentXP=0;
    int NextLevelXP = 100;
    int GemValue = 20;
    public XPBar xpBar;
    public GameObject level;
    private TextMeshPro textMesh;
    bool hasChosen;
    public GameObject choice;
    public GameObject TalentChoice;

    //Pickup
    public Transform PickupRadius;
    float pickupRadius = 0.2f;
    public LayerMask PickupLayer;

    private void Start()
    {
       textMesh = level.GetComponent<TextMeshPro>();
       xpBar.SetMaxXP(NextLevelXP);
    }
    void Update()
    {
        
        //Testing 
        if (Input.GetKeyDown("k"))
        {
            CurrentXP += 100;
        }

        if (CurrentXP >= NextLevelXP)
        {
            LevelUp();
        }
        
        Collider2D[] detectedPickups = Physics2D.OverlapCircleAll(PickupRadius.position, pickupRadius, PickupLayer);
        foreach (Collider2D pickup in detectedPickups)
        {
            GemPickup();
            pickup.GetComponent<SpriteRenderer>().enabled = false;
            pickup.enabled = false;
        }
    }
    

    void LevelUp()
    {
        CurrentXP -= NextLevelXP;
        xpBar.SetCurrentXP(CurrentXP);
        ++Level;
        textMesh.SetText(Level.ToString());
        NextLevelXP += 100;
        xpBar.SetMaxXP(NextLevelXP);

        hasChosen = false;
        ShowChoice();
    }
    void ShowChoice()
    {
        if (Level %5 == 0)
        {
            TalentChoice.gameObject.SetActive(true);
            if (hasChosen)
            {
                Time.timeScale = 1;
                TalentChoice.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
            }
        }

        else
        choice.gameObject.SetActive(true);
        if (hasChosen)
        {
            Time.timeScale = 1;
            choice.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void choose1()
    {
        GetComponent<Spells>().minDam += 10;
        GetComponent<Spells>().maxDam += 10;
        hasChosen = true;
        ShowChoice();
    }
    public void choose2()
    {
        GetComponent<HealthControllerPlayer>().maxHealth += 20;
        GetComponent<HealthControllerPlayer>().currentHealth += 40;
        GetComponent<HealthControllerPlayer>().healthBar.SetMaxHealth((GetComponent<HealthControllerPlayer>().maxHealth));
        GetComponent<HealthControllerPlayer>().healthBar.SetHealth(GetComponent<HealthControllerPlayer>().currentHealth);
        
       hasChosen = true;
        ShowChoice();
    }
    public void choose3()
    {
        GetComponent<PlayerMovement>().moveSpeed += 0.5f;
        GetComponent<Spells>().AttackSpeed1 += 0.2f;
        hasChosen = true;
        ShowChoice();
    }

    public void TalentChoose1()
    {
        GetComponent<StatSheet>().Talent1Tier += 1;
        hasChosen = true;
        ShowChoice();
    }
    public void TalentChoose2()
    {
        GetComponent<StatSheet>().Talent2Tier += 1;
        hasChosen = true;
        ShowChoice();
    }
    public void TalentChoose3()
    {
        GetComponent<StatSheet>().Talent3Tier += 1;
        hasChosen = true;
        ShowChoice();
    }
    public AudioSource audioSource;
    void GemPickup()
    {
        audioSource.Play(); 
        CurrentXP += GemValue;
        xpBar.SetCurrentXP(CurrentXP);
    }
}
