using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] GameObject[] balloons;
    private GameObject randomBalloons;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomBalloons = GetComponent<GameObject>();
        sr = GetComponent<SpriteRenderer>();
        
        sr.sprite = balloons[Random.Range(0, balloons.Length)].GetComponent<SpriteRenderer>().sprite;
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100, 100), Random.Range(100, 200), 0);
        rb.AddForce(force);
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "DestroyArea")
        {
            Destroy(gameObject);
        }
    }
}
