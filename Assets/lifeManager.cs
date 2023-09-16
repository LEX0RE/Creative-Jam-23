using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int player1life = 2;
    public int player2life = 2;
    public LifePlayer Player1;
    public LifePlayer Player2;
    void Start()
    {
        UpdatePlayer1Life();
        UpdatePlayer2Life();
    }
    public void UpdatePlayer1Life() {
        Player1.UpdatePlayerLife(player1life);
    }
    public void UpdatePlayer2Life()
    {
        Player2.UpdatePlayerLife(player2life);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
