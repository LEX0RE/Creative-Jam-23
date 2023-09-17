using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeColider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player") && gameObject.GetComponentInParent<Player>().damagemoment)
        {
            if (gameObject.GetComponentInParent<PlayerController>().name == "Player1") {
                GameObject.FindWithTag("GestionnaireVie").GetComponent<lifeManager>().player2life -=1 ;
                GameObject.FindWithTag("GestionnaireVie").GetComponent<lifeManager>().UpdatePlayer2Life();
            }
            else
            {
                GameObject.FindWithTag("GestionnaireVie").GetComponent<lifeManager>().player1life -= 1;
                GameObject.FindWithTag("GestionnaireVie").GetComponent<lifeManager>().UpdatePlayer1Life();
            }
            Debug.Log("hitt");
        }

    }
}
