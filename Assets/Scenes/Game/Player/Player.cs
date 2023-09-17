using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool damagemoment = false;
    lifeManager lifeMang;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        lifeMang =  GameObject.FindWithTag("GestionnaireVie").GetComponent<lifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerlife();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        QTE.Instance.StartQTEEvent(this);
    }
    public void eventFinishfight()
    {
        gameObject.GetComponentInParent<Animator>().SetBool("Attack", false);
        gameObject.GetComponentInParent<PlayerController>().OnAttack = false;
        damagemoment = false;
    }
    public void StartHIT() {
        damagemoment = true;
    }
    public void checkPlayerlife() {
        if (gameObject.GetComponentInParent<PlayerController>().gameObject.name == "Player1") {
            if (lifeMang.player1life<=0) { gameObject.GetComponent<Animator>().SetBool("Death",true); }
        }
        if (gameObject.GetComponentInParent<PlayerController>().gameObject.name == "Player2")
        {
            if (lifeMang.player2life <= 0) { gameObject.GetComponent<Animator>().SetBool("Death", true); }
        }

    }

}
