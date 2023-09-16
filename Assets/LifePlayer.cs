using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] Lifes;
    public Sprite active;
    public Sprite desactive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePlayerLife(int num) {
        for (int i=0;i<Lifes.Length;i++) {
            Lifes[i].sprite = desactive;
        }
        for (int i = 0; i < num; i++)
        {
            Lifes[i].sprite = active;
        }
    }
}
