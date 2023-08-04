using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] GameObject[] balloons;
    private RuntimeAnimatorController animatorController;
    private GameObject randomBalloons;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;

    int redHealth = 3;
    int yellowHealth = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomBalloons = GetComponent<GameObject>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        int balloonNo = Random.Range(0, balloons.Length);

        anim.runtimeAnimatorController = balloons[balloonNo].GetComponent<Animator>().runtimeAnimatorController;

        sr.sprite = balloons[balloonNo].GetComponent<SpriteRenderer>().sprite;
        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100, 100), Random.Range(100, 200), 0);
        rb.AddForce(force);

    }

    private void OnMouseDown() 
    { //balonlara health sistemi eklenecek - farklı scriptte de olabilir
        // if (gameObject.CompareTag("BlueBalloon"))
        // {
        //     PopBalloon();
        // }
        // if (gameObject.CompareTag("RedBalloon"))
        // {
        //     redHealth--;
        //     if (redHealth <= 0)
        //     {
        //         PopBalloon();
        //     }
        // }
        // if (gameObject.CompareTag("YellowBalloon"))
        // {
        //     yellowHealth--;
        //     if (yellowHealth <= 0)
        //     {
        //         PopBalloon();
        //     }
        // }
        PopBalloon();
    }

    void PopBalloon()
    {
        anim.SetTrigger("Pop");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "DestroyArea")
        {
            Destroy(gameObject);
        }
    }
}
