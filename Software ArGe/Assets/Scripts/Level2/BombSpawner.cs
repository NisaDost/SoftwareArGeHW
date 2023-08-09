using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    float elapsed = 0f;

    StartPanel startPanel;
    void Start()
    {
        startPanel = FindObjectOfType<StartPanel>();
        InvokeRepeating("SpawnBomb", 0f, 2.5f);
    }

    //levele göre belli özelliklerde bomba üretir
    void SpawnBomb()
    {
        if(SceneManager.GetActiveScene().name == "Level2" && startPanel.canStart == true)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            elapsed += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1.5f, 2.8f, elapsed);
        }
        
    }
}
