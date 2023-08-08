using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartPanel : MonoBehaviour
{
    [SerializeField] TMP_Text taskText;
    [SerializeField] Button checkButton;


    void Start()
    {
        
        taskText = GameObject.Find("Tasks").GetComponent<TMP_Text>();
        checkButton = GameObject.Find("CheckButton").GetComponent<Button>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            taskText.text = "● Pop all the given balloons before the time runs out!";
        }
        checkButton.onClick.AddListener(CheckButton);
    }
    void CheckButton()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
