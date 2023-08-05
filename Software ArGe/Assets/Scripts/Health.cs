using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int numOfHearts = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else hearts[i].sprite = emptyHeart;

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else hearts[i].enabled = false;
        }
    }

    public void ReduceHealth()
    {
        this.health--;
        if (health <= 0)
        {
            health = 0;
            //restart panel
        }
    }
}
