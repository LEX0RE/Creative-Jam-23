using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    // Start is called before the first frame update
   public bool isGrounded = false;
    void Start()
    {
        
    }
   
    void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
    void OnTriggerExit(Collider collision)
    {
      
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }

}
