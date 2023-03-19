using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject settingspage;
    [Header("bool")]
    public bool sound;
    public bool vibration;
    [Header("images")]
    public GameObject soundbutton;
    public GameObject disabledsoundbutton;
    public GameObject vibrationbutton;
    public GameObject disabledvibrationbutton;
    public GameObject settingsicon;

    private void Update()
    {
        if (sound)
        {
            soundbutton.SetActive(true);
            disabledsoundbutton.SetActive(false);

}
        else
        {
            soundbutton.SetActive(false);
            disabledsoundbutton.SetActive(true);
        }
        if (vibration)
        {
            vibrationbutton.SetActive(true);
            disabledvibrationbutton.SetActive(false);
        }
        else {
            vibrationbutton.SetActive(false);
            disabledvibrationbutton.SetActive(true);
        }
    }
    public void opensettings()
    {
        settingspage.SetActive(true);
        settingsicon.SetActive(false);
    }
    public void closesettings()
    {
        settingspage.SetActive(false);
        settingsicon.SetActive(true);
    }
    public void changesound() {
        sound = !sound;
    }
    public void changevibration() {
        vibration = !vibration;
    }
}
