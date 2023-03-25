using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour
{
    public GameObject bicakucu;
    public GameObject knifehandler;
    public float rotatespeed;
    public bool rotatescalechanging;
    public bool isrotating;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch tap = Input.GetTouch(0);
            if (tap.phase == TouchPhase.Began)
            {
                rotatespeed = 480;
                rotatescalechanging = true;
                Invoke("starttorotate", 0.3f);
            }
        }
        
        if (transform.eulerAngles.z >= 180 && transform.eulerAngles.z <= 270)
        {
            rotatescalechanging = false;
        }
        else if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z <= 150)
        {
            rotatescalechanging = true;
        }
    }
    private void FixedUpdate()
    {
        if (!rotatescalechanging)
        {
            rotatespeed -= 1400 * Time.fixedDeltaTime;
            if (rotatespeed < 20)
            {
                rotatespeed = 20;
            }
        }
        else { rotatespeed = 480; }
        if (bicakucu.GetComponent<knifefront>().onair)
        {
            transform.Rotate(0, 0, -rotatespeed * Time.fixedDeltaTime);
        }
    }
    public void starttorotate()
    {
        isrotating = true;
    }
}
