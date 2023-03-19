using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifefollow : MonoBehaviour
{
    public GameObject knife;
    void FixedUpdate()
    {
        transform.SetLocalPositionAndRotation(knife.transform.position+new Vector3(-4,5.5f,-8),Quaternion.Euler(30,-325,0));
    }
}
