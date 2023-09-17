using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeColider : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.GetComponentInParent<Player>().damagemoment && !gameObject.GetComponentInParent<Player>().damagedone)
        {
            gameObject.GetComponentInParent<Player>().damagedone = true;
            if (gameObject.GetComponentInParent<PlayerController>().name == "Player1")
            {
                Debug.Log("Damage Player 2");
                GameObject.Find("Player2").GetComponent<PlayerController>().getDamage();
            }
            else if (gameObject.GetComponentInParent<PlayerController>().name == "Player2")
            {
                Debug.Log("Damage Player 1");
                GameObject.Find("Player1").GetComponent<PlayerController>().getDamage();
            }
        }

    }
}
