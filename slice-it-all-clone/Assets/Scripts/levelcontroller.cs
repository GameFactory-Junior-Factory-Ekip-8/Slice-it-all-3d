using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class levelcontroller : MonoBehaviour
{
    GameObject control;
    public GameObject start;
    public GameObject level;
    public GameObject settings;
    void Update()
    {
        control = GameObject.Find("Knifehandler");
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                control.GetComponent<control>().playing = false;
            }
            else
            {
                control.GetComponent<control>().playing = true;
                control.GetComponent<control>().speedy = 1;
                control.GetComponent<control>().speedx = 1;
                start.SetActive(false);
                level.SetActive(false);
                settings.SetActive(false);
            }
        }


    }
}
