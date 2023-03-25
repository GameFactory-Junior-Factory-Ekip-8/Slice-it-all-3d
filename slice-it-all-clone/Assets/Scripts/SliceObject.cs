using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class SliceObject : MonoBehaviour
{
    public Material[] materialSlicedSide;
    public float explosionForce;
    public float explosionRadius;
    public bool gravity, kinematic;
    int randomnumberforcolor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanSlice"))
        {
            randomnumberforcolor = Random.Range(0, 5);
            SlicedHull sliceObj = Slice(other.gameObject, materialSlicedSide[randomnumberforcolor]);
            GameObject SlicedObjTop = sliceObj.CreateUpperHull(other.gameObject, materialSlicedSide[randomnumberforcolor]);
            GameObject SliceObjDown = sliceObj.CreateLowerHull(other.gameObject, materialSlicedSide[randomnumberforcolor]);
            Destroy(other.gameObject);
            AddComponent(SlicedObjTop); 
            AddComponent(SliceObjDown);
        }
    }

    private SlicedHull Slice(GameObject obj, Material mat)
    {
        return obj.Slice(transform.position, transform.up, mat);
    }

    void AddComponent(GameObject obj)
    {
        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity= gravity;
        rigidbody.isKinematic= kinematic;
        rigidbody.AddExplosionForce(explosionForce,obj.transform.position,explosionRadius);
        obj.tag = "CanSlice";
    }
}