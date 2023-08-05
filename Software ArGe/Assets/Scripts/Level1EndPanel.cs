using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1EndPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;

    [SerializeField] Sprite[] banners;
    Image bannerSprite;

    [SerializeField] TMP_Text winStatusText;

    [SerializeField] Button button;
    [SerializeField] SpriteState[] buttonSprite;

    void Start() {
        bannerSprite = GetComponent<Image>();
        
    }

    public void WonPanel()
    {
        //uygun stat yazısı ve buton ekrana gelmiyor
        panel.SetActive(true);
        bannerSprite.sprite = banners[0]; //null reference hatası veriyor
        winStatusText.text = "Level 1 Completed!";
        button.spriteState = buttonSprite[0];

    }
    public void LosePanel()
    {
        panel.SetActive(true);
        bannerSprite.sprite = banners[1];
        winStatusText.text = "You Lose!";
    }
}
