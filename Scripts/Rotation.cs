using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float Rotate = 0;
    void FixedUpdate()
    {
        Rotate += 3;
        transform.localRotation = Quaternion.Euler(0, 0, Rotate);
    }
}
