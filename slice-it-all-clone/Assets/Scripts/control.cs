using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float speedy;
    public float speedx;
    public GameObject bicakucu;
    public float speedmultiple;
    public bool playing;
   
    private void Update()
    {
       
        if (Input.touchCount > 0 &&playing)
        {
            Touch tap = Input.GetTouch(0);
            if (tap.phase == TouchPhase.Began)
            {
                speedy = 1;
                speedx = 1;
            }
        }
       
    }
    void FixedUpdate()
    {
        transform.Translate(speedx * Time.fixedDeltaTime * speedmultiple, 2 * speedy * Time.fixedDeltaTime * speedmultiple, 0);

        if (bicakucu.GetComponent<knifefront>().onair)
        {
            speedy -= Time.fixedDeltaTime;
        }
        
       
    }
}