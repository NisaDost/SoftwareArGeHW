using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;
    float elapsed = 0f;

    void Start()
    {
        InvokeRepeating("SpawnBalloon", 0f, 1f);
    }

    void SpawnBalloon()
    {
        Instantiate(balloonPrefab, transform.position, Quaternion.identity);
        elapsed += Time.deltaTime;
        Time.timeScale = Mathf.Lerp(1f, 4f, elapsed);
        
    }
}
