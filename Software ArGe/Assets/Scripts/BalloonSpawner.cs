using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;

    void Start()
    {
        InvokeRepeating("SpawnBalloon", 0f, 1f);
    }

    void SpawnBalloon()
    {
        Instantiate(balloonPrefab, transform.position, Quaternion.identity);
        
    }
}
