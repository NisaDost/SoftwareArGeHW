using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject purpleBalloonPrefab;
    float elapsed = 0f;

    void Start()
    {
        InvokeRepeating("SpawnPurpleBalloon", 0f, 2.5f);
        
    }
    void SpawnPurpleBalloon()
    {
        Instantiate(purpleBalloonPrefab, transform.position, Quaternion.identity);
        elapsed += Time.deltaTime;
        Time.timeScale = Mathf.Lerp(1.5f, 2.8f, elapsed);
    }
}
