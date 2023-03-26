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
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Finish" || other.gameObject.tag == "CanSlice")
        {
            knifehandler.GetComponent<control>().speedx = -0.5f;
            knifehandler.GetComponent<control>().speedy = -knifehandler.GetComponent<control>().speedy / 4;
        }
    }
}
