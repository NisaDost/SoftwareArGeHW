using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private RuntimeAnimatorController animatorController;
    public BalloonCounter balloonCounter;
    [SerializeField] Vector3 force;
    [SerializeField] GameObject[] balloons; //genel balon için array
    private GameObject randomBalloons; //özel balonlar
    private int balloonNo;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomBalloons = GetComponent<GameObject>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //balloonCounter = GetComponent<BalloonCounter>();

        balloonNo = Random.Range(0, balloons.Length);

        anim.runtimeAnimatorController = balloons[balloonNo].GetComponent<Animator>().runtimeAnimatorController;

        sr.sprite = balloons[balloonNo].GetComponent<SpriteRenderer>().sprite;
        
        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100, 100), Random.Range(100, 200), 0);
        rb.AddForce(force);

    }

    private void OnMouseDown() //bug var :D
    {
        if (balloons[balloonNo].tag == "BlueBalloon")
        {
            Debug.Log("Blue Balloon Clicked");
            balloonCounter.setBlueBalloonNum(balloonCounter.getBlueBalloonNum() - 1);
            Debug.Log(balloonCounter.getBlueBalloonNum() + " Blue Balloon Left");
            if (balloonCounter.getBlueBalloonNum() <= 0)
            {
                balloonCounter.setBlueBalloonNum(0);
            }
        }
        if (balloons[balloonNo].tag == "RedBalloon")
        {
            Debug.Log("Red Balloon Clicked");
            balloonCounter.setRedBalloonNum(balloonCounter.getRedBalloonNum() - 1);
            Debug.Log(balloonCounter.getRedBalloonNum() + " red Balloon Left");

            
            if (balloonCounter.getRedBalloonNum() <= 0)
            {
                balloonCounter.setRedBalloonNum(0);
            }
        }
        if (balloons[balloonNo].tag == "YellowBalloon")
        {
            Debug.Log("Yellow Balloon Clicked");
            balloonCounter.setYellowBalloonNum(balloonCounter.getYellowBalloonNum() - 1);
            Debug.Log(balloonCounter.getYellowBalloonNum() + " Yellow Balloon Left");
            if (balloonCounter.getYellowBalloonNum() <= 0)
            {
                balloonCounter.setYellowBalloonNum(0);
            }
        }
        audioSource.Play();
        PopBalloon();
    }

    void PopBalloon()
    {
        anim.SetTrigger("Pop");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("DestroyArea"))
        {
            Destroy(gameObject);
        }
    }
}
