using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonCounter : MonoBehaviour
{
    [SerializeField] TMP_Text redBalloonCounter;
    [SerializeField] TMP_Text yellowBalloonCounter;
    [SerializeField] TMP_Text blueBalloonCounter;

    [SerializeField] GameObject[] checkImg;
    AudioSource audioSource;
    
    int redBalloonNum;
    int yellowBalloonNum;
    int blueBalloonNum;

    public bool redBalloonCheck = false;
    public bool yellowBalloonCheck = false;
    public bool blueBalloonCheck = false;
    //bool isAllChecked = false;
    
    void Awake()
    {
        redBalloonNum = Random.Range(3, 5);
        yellowBalloonNum = Random.Range(5, 10);
        blueBalloonNum = Random.Range(10, 15);
        audioSource = GetComponent<AudioSource>(); //check audio düzgün çalışmıyor
    }
    void Update()
    {
        redBalloonCounter.text = redBalloonNum.ToString();
        yellowBalloonCounter.text = yellowBalloonNum.ToString();
        blueBalloonCounter.text = blueBalloonNum.ToString();
    }

    public void reduceRedBalloonNum()
    {
        this.redBalloonNum--;
        if (redBalloonNum <= 0)
        {
            redBalloonNum = 0;
            checkImg[0].SetActive(true);
            if (!redBalloonCheck) //plays only once
            {
                redBalloonCheck = true;
                audioSource.Play();
            }
        }
    }
    public void reduceYellowBalloonNum()
    {
        this.yellowBalloonNum--;
        if (yellowBalloonNum <= 0)
        {
            yellowBalloonNum = 0;
            checkImg[1].SetActive(true);
            if (!yellowBalloonCheck) //plays only once
            {
                yellowBalloonCheck = true;
                audioSource.Play();
            }
        }
    }
    public void reduceBlueBalloonNum()
    {
        this.blueBalloonNum--;
        if (blueBalloonNum <= 0)
        {
            blueBalloonNum = 0;
            checkImg[2].SetActive(true);//plays only once
            if (!blueBalloonCheck)
            {
                audioSource.Play();
                blueBalloonCheck = true;
            }
        }
    }
}