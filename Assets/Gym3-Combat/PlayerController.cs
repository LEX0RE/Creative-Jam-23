using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    public bool idle = true;
    public bool mooveLeft = false;
    public bool moove =false;
    private bool rotateApplied =false;
    public GameObject mesh;
    [SerializeField] public float speed = 5;
    private Vector2 movementInput;
    public Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        transform.Translate(new Vector3(0, 5, 0));
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(new Vector3(0, movementInput.y, movementInput.x) * speed * Time.deltaTime);
        moovefunction();
        actionIngame();
    }
    public void actionIngame() { 
    //bool ispressingR = move
    
    }
    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void moovefunction() {
        if (movementInput.x * 100 < 1 && movementInput.x * 100 > -1 & movementInput.y * 100 < 1)
        {
            idle = true;
            moove = false;
            mooveLeft = false;
            animator.SetBool("Run", false);
        }
        else {
            idle = false;
            moove = true;
            animator.SetBool("Run",true);
            if (movementInput.x < 0)
            {
                mooveLeft = true;
                if (!rotateApplied) {
                    mesh.transform.Rotate(gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z);
                    rotateApplied = true;
                  
                }
               
            }
            else {
                mooveLeft = false;
                if (rotateApplied) {
                    mesh.transform.Rotate(gameObject.transform.rotation.x, -180, gameObject.transform.rotation.z);
                    
                    rotateApplied = false;
                }
            }

        }
        Debug.Log("x"+ movementInput.x * 100);
    }
}
