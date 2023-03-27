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
            
            other.gameObject.tag = "Untagged";
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
    void slice()
    {



    }
    void AddComponent(GameObject obj)
    {
        obj.gameObject.tag = "Untagged";
        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity= true;
        rigidbody.isKinematic= false;
        rigidbody.AddExplosionForce(explosionForce,obj.transform.position,explosionRadius);
    }
}