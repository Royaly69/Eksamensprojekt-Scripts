using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshPro textMesh;
    int SecTimer = 0;
    public int minTimer = 0;
    public int levelTime;
    int previousTime;
    public int maxHealth = 100;
    float HealthTime = 0;

    private void Start()
    {
        previousTime = (int)Time.time;
    }
    void Update()
    {
        levelTime = ((int)Time.time - previousTime);
        if (levelTime <= 60)
        {
            SecTimer = levelTime;
        }
        else
        {
            minTimer = levelTime / 60;
            SecTimer = levelTime - minTimer * 60;
        }
        if (SecTimer > 10 && minTimer > 10)
        {
            textMesh.text = (minTimer + ":" + SecTimer);
        }
        else if (minTimer < 10 && SecTimer < 10)
        {
            textMesh.text = ("0"+minTimer + ":0" + SecTimer);
        }
        else if (minTimer >= 10 && SecTimer < 10)
        {
            textMesh.text = (minTimer + ":0" + SecTimer);
        }
        else if (minTimer < 10 && SecTimer >= 10)
        {
            textMesh.text = ("0"+minTimer + ":" + SecTimer);
        }
        //enemy health increase
        
        
        if (Time.time >= HealthTime)
        {
            maxHealth += 1;
            Debug.Log(maxHealth);
            HealthTime += 10;
        }

        
        

    }
}
