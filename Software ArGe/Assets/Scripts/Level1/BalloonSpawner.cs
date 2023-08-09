using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;
    public StartPanel startPanel;
    float elapsed = 0f;

    void Start()
    {
        startPanel = FindObjectOfType<StartPanel>();
        InvokeRepeating("SpawnBalloon", 0f, 1f);
    }

    //levele göre belli özelliklerde balon üretir
    void SpawnBalloon()
    {
        if(SceneManager.GetActiveScene().name == "Level1" && startPanel.canStart == true)
        {
            Instantiate(balloonPrefab, transform.position, Quaternion.identity);
            elapsed += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1.2f, 2f, elapsed);
        }
        if(SceneManager.GetActiveScene().name == "Level2" && startPanel.canStart == true)
        {
            Instantiate(balloonPrefab, transform.position, Quaternion.identity);
            elapsed += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1.5f, 2.8f, elapsed);
        }
    }
}
