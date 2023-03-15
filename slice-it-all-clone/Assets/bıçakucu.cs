using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bıçakucu : MonoBehaviour
{
    public GameObject knifehandler;
    public bool onair;
    public bool triggertrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            onair = false;
            knifehandler.GetComponent<control>().speedy = knifehandler.GetComponent<control>().speedx = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        onair = true;
    }
}
