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
    private int balloonNo; //array içine atanıp balon belirlemek için
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;

    Level1EndPanel level1EndPanel;
    void Start()
    {
        balloonCounter = FindObjectOfType<BalloonCounter>(); // bu referans olmazsa balon sayısı ekrana yazılmaz

        level1EndPanel = FindObjectOfType<Level1EndPanel>();

        rb = GetComponent<Rigidbody2D>();
        randomBalloons = GetComponent<GameObject>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        balloonNo = Random.Range(0, balloons.Length);

        anim.runtimeAnimatorController = balloons[balloonNo].GetComponent<Animator>().runtimeAnimatorController;

        sr.sprite = balloons[balloonNo].GetComponent<SpriteRenderer>().sprite;
        
        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100, 100), 150, 0);
        rb.AddForce(force);

    }

    public void OnMouseDown()
    {
        audioSource.Play();
        PopBalloon();
        if (balloons[balloonNo].tag == "RedBalloon")
        {
            //Debug.Log("Red Balloon Clicked");
            balloonCounter.ReduceRedBalloonNum();
        }
        if (balloons[balloonNo].tag == "YellowBalloon")
        {
            //Debug.Log("Yellow Balloon Clicked");
            balloonCounter.ReduceYellowBalloonNum();
        }
        if (balloons[balloonNo].tag == "BlueBalloon")
        {
            //Debug.Log("Blue Balloon Clicked");
            balloonCounter.ReduceBlueBalloonNum();                        
        }
        GetComponent<Collider2D>().enabled = false;
    }
    void Update()
    {
        if(level1EndPanel.isPanelActive == true)
        {
            Destroy(gameObject);
        }
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

    void DestroyBalloons()
    {
        
    }
}
