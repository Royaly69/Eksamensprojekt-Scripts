using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform target;

    public float FollowSpeed = 0.2f;
    public Vector3 offset;
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
