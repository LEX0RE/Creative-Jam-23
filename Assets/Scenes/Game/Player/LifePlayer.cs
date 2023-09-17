using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Sprite active;
    [SerializeField] public Sprite desactive;
    public Image[] Lifes;
    void Start()
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            Color tempColor = Lifes[i].color;
            tempColor.a = 0f;
            Lifes[i].color = tempColor;
        }
        if (gameObject.name == "Player1-Vie" && GameObject.Find("Player1"))
        {
            GameObject.Find("Player1").GetComponent<PlayerController>().playerLife = this;
        }
        else if (gameObject.name == "Player2-Vie" && GameObject.Find("Player2"))
        {
            GameObject.Find("Player2").GetComponent<PlayerController>().playerLife = this;
        }
    }
    public void UpdatePlayerLife(int num)
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            Color tempColor = Lifes[i].color;
            tempColor.a = 1f;
            Lifes[i].color = tempColor;
            Lifes[i].sprite = desactive;
        }
        for (int i = 0; i < num; i++)
        {
            Lifes[i].sprite = active;
        }
    }
}
