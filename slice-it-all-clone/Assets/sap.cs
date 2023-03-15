using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sap : MonoBehaviour
{
    public GameObject knifehandler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            knifehandler.GetComponent<control>().speedx = -knifehandler.GetComponent<control>().speedx;
            knifehandler.GetComponent<control>().speedy = -knifehandler.GetComponent<control>().speedy;
        }
    }
}
