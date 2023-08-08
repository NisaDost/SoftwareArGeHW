using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject purpleBalloonPrefab;
    float elapsed = 0f;

    int rng = 5;

    void Start()
    {
        InvokeRepeating("RNG", 0f, 1f);
        
        InvokeRepeating("SpawnPurpleBalloon", 0f, 1f);
        
        
    }
    int RNG()
    {
        return Random.Range(0, 15);
    }
    void SpawnPurpleBalloon()
    {
       if(RNG() == rng)
        {
            Instantiate(purpleBalloonPrefab, transform.position, Quaternion.identity);
        }
        elapsed += Time.deltaTime;
        Time.timeScale = Mathf.Lerp(1f, 2f, elapsed);
    }
}
