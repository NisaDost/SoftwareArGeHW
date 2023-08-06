using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1EndPanel : MonoBehaviour
{
    Health health;

    [SerializeField] GameObject panel; //setactive yapılacak obje

    [SerializeField] GameObject panelBG; 
    [SerializeField] Sprite[] banners;
    Image banner;

    [SerializeField] TMP_Text winStatusText;

    [SerializeField] Button button;
    [SerializeField] Sprite[] buttonSprites;
    Sprite buttonSprite;

    void Start()
    {
        banner = panelBG.GetComponent<Image>();
        health = FindObjectOfType<Health>();
    }

    public void WonPanel()
    {
        panel.SetActive(true);
        banner.sprite = banners[0];
        winStatusText.text = "Level 1 Completed!";
        button.image.sprite = buttonSprites[0];
        button.onClick.AddListener(NextLevel);

    }
    public void LosePanel()
    {
        panel.SetActive(true);
        banner.sprite = banners[1];
        winStatusText.text = "You Lose!";
        button.image.sprite = buttonSprites[1];
        button.onClick.AddListener(Retry);
    }

    public void Retry(){
        health.ReduceHealth(); // can 2 kere azalıyor
        if(health.ReduceHealth() <= 0){
            winStatusText.text = "No more lives left!";
            button.enabled = false; //disable olmadı
            health.StartHealthTimer(health.heartCooldown);
        }
        else{
            SceneManager.LoadScene("Level1");
        }
    }
    public void NextLevel(){
        SceneManager.LoadScene("Level2");
    }

}
