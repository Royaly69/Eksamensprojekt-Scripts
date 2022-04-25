using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7,8);
        Physics2D.IgnoreLayerCollision(6,8);
    }
}
