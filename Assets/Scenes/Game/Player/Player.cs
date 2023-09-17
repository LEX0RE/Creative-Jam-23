using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool damagemoment = false;
    public bool damagedone = false;

    public void eventFinishfight()
    {
        gameObject.GetComponentInParent<Animator>().SetBool("Attack", false);
        gameObject.GetComponentInParent<PlayerController>().OnAttack = false;
        damagemoment = false;
        damagedone = false;
    }
    public void StartHIT()
    {
        damagedone = false;
        damagemoment = true;
    }
}
