using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public TMP_Text pointsText;
    public void Setup(int winner)
    {
        gameObject.SetActive(true);
        pointsText.text = "Winner : Player " + winner.ToString();
    }

    public void RestartGame()
    {
        PlayerController.nextId = 1;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

