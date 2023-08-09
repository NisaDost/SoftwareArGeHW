using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurpleBalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject purpleBalloonPrefab;
    StartPanel startPanel;
    float elapsed = 0f;

    int rng = 5;

    void Start()
    {
        startPanel = FindObjectOfType<StartPanel>();

        InvokeRepeating("RNG", 0f, 1f);
        //üretilen rastgele sayıya göre mor balon üretir
        InvokeRepeating("SpawnPurpleBalloon", 0f, 1f);
    }
    //rasgele sayı üretir
    int RNG()
    {
        return Random.Range(0, 12);
    }

    //levele göre belli özelliklerde mor balon üretir
    void SpawnPurpleBalloon()
    {
        if(SceneManager.GetActiveScene().name == "Level2" && startPanel.canStart == true)
        {
            if(RNG() == rng)
                {
                    Instantiate(purpleBalloonPrefab, transform.position, Quaternion.identity);
                }
            elapsed += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1.5f, 2.8f, elapsed);
        }
    }
}
