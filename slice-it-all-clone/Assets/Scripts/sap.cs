using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sap : MonoBehaviour
{

    public GameObject gamecontrol;
    public GameObject knifehandler;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "loseground")
        {
            gamecontrol.GetComponent<gamecontrol>().lose();

        }
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Finish")
        {
            knifehandler.GetComponent<control>().speedx = -0.5f;
            knifehandler.GetComponent<control>().speedy = -knifehandler.GetComponent<control>().speedy / 4;
        }
        if(other.gameObject.tag == "CanSlice")
        {
            other.gameObject.AddComponent<BoxCollider>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, knifehandler.GetComponent<control>().speedy, knifehandler.GetComponent<control>().speedx);
            knifehandler.GetComponent<control>().speedx = -0.5f;
            knifehandler.GetComponent<control>().speedy = -knifehandler.GetComponent<control>().speedy / 4;
        }
    }
}
