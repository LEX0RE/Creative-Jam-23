using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si le joueur entre en collision avec un objet ayant un collider
        // Vous pouvez ajuster cette condition en fonction de vos besoins

        if (collision.collider.CompareTag("Obstacle"))
        {
            // Si le joueur entre en collision avec un objet "Obstacle", arr�tez son mouvement en r�initialisant sa v�locit�
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}