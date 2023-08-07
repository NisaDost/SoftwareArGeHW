using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    float elapsed = 0f;

    void Start()
    {
        InvokeRepeating("SpawnBomb", 0f, 1f);
    }

    void SpawnBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        elapsed += Time.deltaTime;
        Time.timeScale = Mathf.Lerp(1f, 2.4f, elapsed);
        
    }
}
