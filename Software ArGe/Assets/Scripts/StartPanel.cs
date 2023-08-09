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

    public bool canStart = false;

    void Start()
    {
        Time.timeScale = 0;
        taskText = GameObject.Find("Tasks").GetComponent<TMP_Text>();
        checkButton = GameObject.Find("CheckButton").GetComponent<Button>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            taskText.text = "● Pop all the given balloons before the time runs out!";
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            taskText.text = "● Avoid the bombs!\n● Purple balloons add +1 to other balloon numbers unless they are 0!";
        }
        checkButton.onClick.AddListener(CheckButton);
    }
    void CheckButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        canStart = true;
    }
}
