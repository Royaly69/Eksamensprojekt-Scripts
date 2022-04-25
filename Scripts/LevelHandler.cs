using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{
    public GameObject xpHandler;
    void Update()
    {
        int level = xpHandler.GetComponent<XPHandler>().Level;
        GetComponent<TextMeshPro>().text = level.ToString();
    }
}
