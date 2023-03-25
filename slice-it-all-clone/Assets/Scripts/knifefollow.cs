using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knıfefollow : MonoBehaviour
{
    public GameObject knife;
    void FixedUpdate()
    {
        transform.SetLocalPositionAndRotation(knife.transform.position + new Vector3(8, 3, -7), Quaternion.Euler(12, -42, 0));
    }
}
