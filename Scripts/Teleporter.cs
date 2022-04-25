using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject timer;
    public GameObject teleporter;
    void Start()
    {
        
    }
    void Update()
    {
        if (timer.GetComponent<Timer>().minTimer == 5)
        {
            Teleporter();
        };
        void Teleporter()
        {
            teleporter.SetActive(true);
        }
    }
}
