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
            if (gameObject.GetComponentInParent<PlayerController>().name == "Player1")
            {
                GameObject.Find("Player2").GetComponent<PlayerController>().getDamage();
            }
            else
            {
                GameObject.Find("Player1").GetComponent<PlayerController>().getDamage();
            }
            Debug.Log("hitt");
        }

    }
}
