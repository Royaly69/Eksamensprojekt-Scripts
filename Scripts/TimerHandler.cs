using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHandler : MonoBehaviour
{
    public GameObject timeHandler;
    void Update()
    {
        string time = timeHandler.GetComponent<Timer>().textMesh.text;
        GetComponent<TextMeshPro>().text = time;
    }
}
