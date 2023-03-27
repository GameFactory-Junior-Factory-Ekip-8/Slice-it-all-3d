using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifefront : MonoBehaviour
{
    public GameObject settings;
    public GameObject rotater;
    public GameObject gamecontrol;
    public GameObject knifehandler;
    public bool onair;
    public bool triggerworking;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch tap = Input.GetTouch(0);
            if (tap.phase == TouchPhase.Began)
            {
                StartCoroutine(TriggerControl());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground" && triggerworking)
        {
            onair = false;
            knifehandler.GetComponent<control>().speedy = knifehandler.GetComponent<control>().speedx = 0;
        }
        if (other.gameObject.tag == "losingground")
        {
            gamecontrol.GetComponent<gamecontrol>().lose();

        }
        if (other.gameObject.tag == "CanSlice")
        {
            
            gamecontrol.GetComponent<gamecontrol>().gainedmoney++;


        }
        if (other.gameObject.tag == "Finish")
        {
            gamecontrol.GetComponent<gamecontrol>().multiple = other.gameObject.GetComponent<multiplenumber>().number;



            gamecontrol.GetComponent<gamecontrol>().win();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CanSlice")
        {
            rotater.GetComponent<rotating>().isrotating = true;
            onair = true;
        }
        else { onair = true; }
       
    }
    IEnumerator TriggerControl()
    {
        triggerworking = false;
        yield return new WaitForSecondsRealtime(0.5f);
        triggerworking = true;
    }
    
}
