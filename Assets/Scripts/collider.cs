using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur entre en collision avec un objet ayant un collider
        // Vous pouvez ajuster cette condition en fonction de vos besoins

        if (collision.collider.CompareTag("Obstacle"))
        {
            // Si le joueur entre en collision avec un objet "Obstacle", arrêtez son mouvement en réinitialisant sa vélocité
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}