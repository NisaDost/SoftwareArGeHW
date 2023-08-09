using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1EndPanel : MonoBehaviour
{
    Health health;
    [SerializeField] TMP_Text healthTimerText;

    [SerializeField] GameObject panel;

    [SerializeField] GameObject panelBG; 
    [SerializeField] Sprite[] banners;
    Image banner;

    [SerializeField] TMP_Text winStatusText;

    [SerializeField] Button button;
    [SerializeField] Sprite[] buttonSprites;

    [SerializeField] TMP_Text timerCountdownText;

    StartPanel startPanel;

    public bool isPanelActive = false;

    Animator hourglassAnim;
    Timer timer;

    void Start()
    {
        startPanel = FindObjectOfType<StartPanel>();
        banner = panelBG.GetComponent<Image>();
        health = FindObjectOfType<Health>();
        hourglassAnim = GameObject.Find("Hourglass").GetComponent<Animator>();
        timer = FindObjectOfType<Timer>();
        timerCountdownText = GameObject.Find("TimerCountDown").GetComponent<TMP_Text>();
    }

    //oyun kazanıldığında ekrana kazanma paneli getirir
    public void WonPanel()
    {
        isPanelActive = true;
        panel.SetActive(true);

        startPanel.canStart = false;
        banner.sprite = banners[0];
        hourglassAnim.enabled = false;

        timerCountdownText.enabled = false;

        if(SceneManager.GetActiveScene().name == "Level1")
        {
            winStatusText.text = "Level 1 Completed!";
            button.image.sprite = buttonSprites[0];
            button.onClick.AddListener(NextLevel);
            startPanel.canStart = false;
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            winStatusText.text = "Game Completed!";
            button.image.sprite = buttonSprites[2];
            button.onClick.AddListener(Home);
            startPanel.canStart = false;
        }

    }
    //oyun kaybedildiğinde levele göre ekrana kaybetme paneli getirir
    public void LosePanel()
    {   
        isPanelActive = true;
        panel.SetActive(true);
        
        startPanel.canStart = false;
        health.ReduceHealth();
        banner.sprite = banners[1];
        button.image.sprite = buttonSprites[1];
        hourglassAnim.enabled = false;

        timerCountdownText.enabled = false;

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if(health.GetHealth() <= 0)
            {
                winStatusText.text = "No more lives left!";
                button.interactable = false;
            }
            else
            {
                winStatusText.text = "You Lose!";
                button.interactable = true;
                button.onClick.AddListener(Retry);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if(health.GetHealth() <= 0)
            {
                winStatusText.text = "No more lives left!";
                button.interactable = false;
            }
            else
            {
                winStatusText.text = "You Lose!";
                button.interactable = true;
                button.onClick.AddListener(Retry2);
            }
        }
    }

    public void Retry2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void Retry()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync("Entry");
        health.SetHealth(3);
    }
}

