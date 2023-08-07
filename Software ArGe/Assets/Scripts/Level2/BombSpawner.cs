using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    float elapsed = 0f;

    void Start()
    {
        InvokeRepeating("SpawnBomb", 0f, 2.5f);
    }

    void SpawnBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        elapsed += Time.deltaTime;
        Time.timeScale = Mathf.Lerp(1.5f, 2.8f, elapsed);
        
    }
}
