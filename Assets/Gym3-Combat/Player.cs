using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
