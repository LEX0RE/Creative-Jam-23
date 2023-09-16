using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject qte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        if(qte)
        {
            ShowQTE();
        }
    }

    void ShowQTE()
    {
        //Instantiate(qte, transform.position, Quaternion.Identity, )
    }
}
