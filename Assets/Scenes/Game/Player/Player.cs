using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool damagemoment = false;

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
}
