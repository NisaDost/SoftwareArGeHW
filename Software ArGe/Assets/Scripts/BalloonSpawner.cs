using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("SpawnBalloon", 0f, 1f);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Balloon")
            {
                anim.SetTrigger("Pop");
            }
        }
    }
    void SpawnBalloon()
    {
        Instantiate(balloonPrefab, transform.position, Quaternion.identity);
        
    }
}
