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
    
    int redBalloonNum;
    int yellowBalloonNum;
    int blueBalloonNum;

    public bool redBalloonCheck;
    public bool yellowBalloonCheck;
    public bool blueBalloonCheck;

    void Awake()
    {
        redBalloonNum = Random.Range(3, 5);
        yellowBalloonNum = Random.Range(5, 10);
        blueBalloonNum = Random.Range(10, 15);

        Debug.Log("Red Balloon number: " + redBalloonNum);
        Debug.Log("Yellow Balloon number: " + yellowBalloonNum);
        Debug.Log("Blue Balloon number: " + blueBalloonNum);
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
            redBalloonCheck = true;
        }
    }
    public void reduceYellowBalloonNum()
    {
        this.yellowBalloonNum--;
        if (yellowBalloonNum <= 0)
        {
            yellowBalloonNum = 0;
            checkImg[1].SetActive(true);
            yellowBalloonCheck = true;
        }
    }
    public void reduceBlueBalloonNum()
    {
        this.blueBalloonNum--;
        if (blueBalloonNum <= 0)
        {
            blueBalloonNum = 0;
            checkImg[2].SetActive(true);
            blueBalloonCheck = true;
        }
    }
}
