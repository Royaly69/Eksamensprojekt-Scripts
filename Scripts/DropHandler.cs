using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHandler : MonoBehaviour
{
    public GameObject drop;
    public void createDrop()
    {
        GameObject Drop = Instantiate(drop);
        Drop.transform.position = transform.position;
        this.enabled = false;
    }
}
