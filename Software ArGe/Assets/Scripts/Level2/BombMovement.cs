using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
   
    [SerializeField] Vector3 force;
    [SerializeField] GameObject bomb;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;

    Level1EndPanel level1EndPanel;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
  
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        level1EndPanel = FindObjectOfType<Level1EndPanel>();


        anim = bomb.GetComponent<Animator>();

        sr.sprite = bomb.GetComponent<SpriteRenderer>().sprite;
        
        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100, 100), 150, 0);
        rb.AddForce(force);

    }

    private void OnMouseDown()
    {
        audioSource.Play();
        Explode();
        
        Time.timeScale = 0f;
        level1EndPanel.LosePanel();

        GetComponent<Collider2D>().enabled = false;
    }

    void Explode()
    {
        anim.SetTrigger("Boom");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("DestroyArea"))
        {
            Destroy(gameObject);
        }
    }
}
