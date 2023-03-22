using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gamecontrol : MonoBehaviour
{
    [Header("canvas")]
    public GameObject levelnumber;
    public GameObject winscreen;
    public GameObject losescreen;
    public GameObject moneytext;
    public GameObject endmoneytext;
    public GameObject nextlevelbutton;
    [Header("money")]
    public float savedmoney;
    public float gainedmoney;
    public float multiple;
    [Header("GameObjects")]
    public GameObject knifefront;
    public GameObject control;
    public GameObject camerafollow;

    private void Start()
    {
        if (PlayerPrefs.HasKey("savedmoney"))
        {
            savedmoney = PlayerPrefs.GetFloat("savedmoney");
        }
        moneytext.GetComponent<TextMeshProUGUI>().text = "$ " + (savedmoney + gainedmoney).ToString();
        levelnumber.GetComponent<TextMeshProUGUI>().text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex+1).ToString();
    }
    private void Update()
    {
        if (control.GetComponent<control>().playing == true) { moneytext.GetComponent<TextMeshProUGUI>().text = "$ " + (savedmoney+gainedmoney).ToString(); }
    }

    public void win()
    {
        knifefront.GetComponent<knifefront>().onair = false;
        control.GetComponent<control>().speedx = control.GetComponent<control>().speedy = 0;
        control.GetComponent<control>().playing = false;
        camerafollow.GetComponent<knifefollow>().follow = false;
        Invoke("openwinscreen", 1);
    }
    public void openwinscreen()
    {
        endmoneytext.GetComponent<TextMeshProUGUI>().text ="+" +(gainedmoney * multiple).ToString();
        winscreen.SetActive(true);
    }
    public void lose() {
        knifefront.GetComponent<knifefront>().onair = false;
        control.GetComponent<control>().speedx = control.GetComponent<control>().speedy =0;
        control.GetComponent<control>().playing = false;
        camerafollow.GetComponent<knifefollow>().follow = false;
        Invoke("openlosescreen",1);
    }
    public void openlosescreen() {
        losescreen.SetActive(true);
    }
    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
public void nextlevel() {
        StartCoroutine(addmoney());
    }
    public IEnumerator addmoney()
    {
        nextlevelbutton.SetActive(false);
        for(float i =0;i<= gainedmoney * multiple; i++) {

            endmoneytext.GetComponent<TextMeshProUGUI>().text = "+" + ((gainedmoney * multiple)-i).ToString();
            moneytext.GetComponent<TextMeshProUGUI>().text = "$ " + ((savedmoney + gainedmoney)+i).ToString();
            yield return new WaitForSecondsRealtime(0.0025f);
        }
        yield return new WaitForSecondsRealtime(2);
        PlayerPrefs.SetFloat("savedmoney",savedmoney+(gainedmoney*multiple));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("savedmoney", savedmoney + (gainedmoney * multiple));
    }


}
