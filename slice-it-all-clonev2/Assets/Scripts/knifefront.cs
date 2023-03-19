using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifefront : MonoBehaviour
{
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
        if (other.gameObject.tag == "ground"&&triggerworking)
        {
            onair = false;
            knifehandler.GetComponent<control>().speedy = knifehandler.GetComponent<control>().speedx = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        onair = true;
    }
    IEnumerator TriggerControl()
    {
        triggerworking = false;
        yield return new WaitForSecondsRealtime(0.5f);
        triggerworking = true;
    }
}
