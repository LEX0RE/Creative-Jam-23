using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool damagemoment = false;
    lifeManager lifeManag;
    // Start is called before the first frame update
    void Start()
    {
        lifeManag = GameObject.FindWithTag("GestionnaireVie").GetComponent<lifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerlife();
    }

    public void eventFinishfight()
    {
        gameObject.GetComponentInParent<Animator>().SetBool("Attack", false);
        gameObject.GetComponentInParent<PlayerController>().OnAttack = false;
        damagemoment = false;
    }
    public void StartHIT()
    {
        damagemoment = true;
    }
    public void checkPlayerlife()
    {
        if (gameObject.GetComponentInParent<PlayerController>().gameObject.name == "Player1")
        {
            if (lifeManag.player1life <= 0)
            {
                gameObject.GetComponent<Animator>().SetBool("Death", true);
                QTE.Instance.StartQTEEvent(this);
            }
        }
        if (gameObject.GetComponentInParent<PlayerController>().gameObject.name == "Player2")
        {
            if (lifeManag.player2life <= 0)
            {
                gameObject.GetComponent<Animator>().SetBool("Death", true);
                QTE.Instance.StartQTEEvent(this);
            }
        }

    }

}
