using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] GameObject soundButton;
    [SerializeField] Sprite[] audioSprite;

    void Start()
    {
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        soundButton = GameObject.Find("SoundButton");
        
        if (AudioListener.volume == 1f)
        {
            soundButton.GetComponent<Image>().sprite = audioSprite[0];
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = audioSprite[1];
        }
    }

    public void Play(){
        SceneManager.LoadSceneAsync("Level1");
    }
    public void Mute(){
        if (AudioListener.volume == 1f)
        {
            AudioListener.volume = 0f;
            soundButton.GetComponent<Image>().sprite = audioSprite[1];
        }
        else
        {
            AudioListener.volume = 1f;
            soundButton.GetComponent<Image>().sprite = audioSprite[0];

        }
    }
}
