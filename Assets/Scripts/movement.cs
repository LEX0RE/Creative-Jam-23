using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeplacementSautPersonnage : MonoBehaviour
{
    public float vitesseDeplacement = 5.0f; // Vitesse de déplacement du personnage
    public float forceDeSaut = 10.0f; // Force du saut
    private Rigidbody rb;
    private bool peutSauter = true;

    private void Start()
    {
        // Récupérer le composant Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Obtenir l'entrée horizontale (axe gauche/droite)
        float deplacementHorizontal = Input.GetAxis("Horizontal");

        // Déplacer le personnage horizontalement
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0.0f, 0.0f);
        Vector3 nouvellePosition = rb.position + deplacement * vitesseDeplacement * Time.deltaTime;
        rb.MovePosition(nouvellePosition);

        // Gérer le saut
        if (peutSauter && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * forceDeSaut, ForceMode.Impulse);
            peutSauter = false; // Empêche de sauter à nouveau jusqu'à ce que le personnage touche le sol
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Réactiver la possibilité de sauter lorsque le personnage touche le sol
        if (collision.gameObject.CompareTag("Sol"))
        {
            peutSauter = true;
        }
    }
}


