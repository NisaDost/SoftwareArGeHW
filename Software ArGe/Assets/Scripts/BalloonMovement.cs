using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] balloons;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        force = new Vector3(Random.Range(-100, 100), Random.Range(100, 200), 0);
        rb.AddForce(force);
        spriteRenderer.sprite = balloons[Random.Range(0, balloons.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
