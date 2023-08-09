using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBalloonMovement : MonoBehaviour
{
    RuntimeAnimatorController runtimeAnimatorController;
    [SerializeField] Vector3 force;
    [SerializeField] GameObject purpleBalloon;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;

    Level1EndPanel level1EndPanel;
    BalloonCounter balloonCounter;
    Timer timer;

    void Start()
    {
        balloonCounter = FindObjectOfType<BalloonCounter>();
        timer = FindObjectOfType<Timer>();
        rb = GetComponent<Rigidbody2D>();
  
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        level1EndPanel = FindObjectOfType<Level1EndPanel>();

        anim = purpleBalloon.GetComponent<Animator>();

        anim.runtimeAnimatorController = purpleBalloon.GetComponent<Animator>().runtimeAnimatorController;

        sr.sprite = purpleBalloon.GetComponent<SpriteRenderer>().sprite;
        
        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100, 100), 150, 0);
        rb.AddForce(force);
    }

      void Update()
    {
        if(level1EndPanel.isPanelActive == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        audioSource.Play();
        Pop();

        balloonCounter.ReducePurpleBalloonNum();
        balloonCounter.IncreaseRedBalloonNum();
        balloonCounter.IncreaseYellowBalloonNum();
        balloonCounter.IncreaseBlueBalloonNum();

        GetComponent<Collider2D>().enabled = false;
    }

    void LoadLosePanel()
    {
        level1EndPanel.LosePanel(); // animasyonda event ile çağırdım
    }

    void Pop()
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
