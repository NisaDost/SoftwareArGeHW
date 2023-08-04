using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonCounter : MonoBehaviour
{
    [SerializeField] TMP_Text redBalloonCounter;
    [SerializeField] TMP_Text yellowBalloonCounter;
    [SerializeField] TMP_Text blueBalloonCounter;
    
    private int redBalloonNum = ;
    private int yellowBalloonNum;
    private int blueBalloonNum;

    void Start()
    {
        redBalloonNum = 5;
        yellowBalloonNum = 10;
        blueBalloonNum = 15;
    }
    void Update()
    {
        redBalloonCounter.text = redBalloonNum.ToString();
        yellowBalloonCounter.text = yellowBalloonNum.ToString();
        blueBalloonCounter.text = blueBalloonNum.ToString();
    }
    public void setRedBalloonNum(int num)
    {
        this.redBalloonNum = num;
    }
    public int getRedBalloonNum()
    {
        return redBalloonNum;
    }
    public void setYellowBalloonNum(int num)
    {
        this.yellowBalloonNum = num;
    }
    public int getYellowBalloonNum()
    {
        return yellowBalloonNum;
    }
    public void setBlueBalloonNum(int num)
    {
        this.blueBalloonNum = num;
    }
    public int getBlueBalloonNum()
    {
        return blueBalloonNum;
    }
}
