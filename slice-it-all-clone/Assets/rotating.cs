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
                rotatespeed = 270;
                rotatescalechanging = true;
    Invoke("starttorotate", 0.15f);
            }



        }
        
        if (transform.eulerAngles.z >= 180&& transform.eulerAngles.z <= 270)
        {
            rotatescalechanging = false;

        }
    }
    private void FixedUpdate()
    {
        if (!rotatescalechanging)
        {
 rotatespeed -= 360*Time.fixedDeltaTime;
            if (rotatespeed < 15)
            {
                rotatespeed = 15;
            }

        }
        if (bicakucu.GetComponent<býçakucu>().onair)
        {
transform.Rotate(0,0,-rotatespeed*Time.fixedDeltaTime);
        }
        
    }
  public void starttorotate()
    {
        isrotating = true;


    }
}
