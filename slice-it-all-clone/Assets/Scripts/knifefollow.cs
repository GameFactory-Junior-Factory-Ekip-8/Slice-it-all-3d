using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifefollow : MonoBehaviour
{
    public GameObject knife;
    public bool follow;
    void FixedUpdate()
    {
        if (follow) { transform.SetLocalPositionAndRotation(knife.transform.position + new Vector3(8, 3, -7), Quaternion.Euler(12, -42, 0)); }
    }
}

