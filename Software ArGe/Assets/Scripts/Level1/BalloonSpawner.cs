using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            Time.timeScale = Mathf.Lerp(1f, 2f, elapsed);
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            Time.timeScale = Mathf.Lerp(1.5f, 2.8f, elapsed);
        }
        
    }
}
