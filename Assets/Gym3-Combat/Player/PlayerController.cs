using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    public bool idle = true;
    public bool mooveLeft = false;
    public bool moove = false;
    private bool rotateApplied = false;
    public GameObject mesh;
    [SerializeField] public float speed = 3;
    private Vector2 movementInput;
    public Animator animator;
    public bool inQTE = false;


    private void Start()
    {
        inQTE = false;
        transform.Translate(new Vector3(0, 5, 0));
        QTE.Instance.AddPlayer(this);
    }

    private void Update()
    {
        if (!inQTE)
        {
            transform.Translate(new Vector3(0, movementInput.y, movementInput.x) * speed * Time.deltaTime);
            moovefunction();
            actionIngame();
        }
    }
    public void actionIngame()
    {

    }
    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void moovefunction()
    {
        if (movementInput.x * 100 < 1 && movementInput.x * 100 > -1 & movementInput.y * 100 < 1)
        {
            idle = true;
            moove = false;
            mooveLeft = false;
            animator.SetBool("Run", false);
        }
        else
        {
            idle = false;
            moove = true;
            animator.SetBool("Run", true);
            if (movementInput.x < 0)
            {
                mooveLeft = true;
                if (!rotateApplied)
                {
                    mesh.transform.Rotate(gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z);
                    rotateApplied = true;

                }

            }
            else
            {
                mooveLeft = false;
                if (rotateApplied)
                {
                    mesh.transform.Rotate(gameObject.transform.rotation.x, -180, gameObject.transform.rotation.z);

                    rotateApplied = false;
                }
            }
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
    public void OnCross(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                Debug.Log(ButtonControl.Cross);
                QTE.Instance.SendCombo(ButtonControl.Cross);
            }
            else
            {

            }
        }
    }
    public void OnCircle(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                Debug.Log(ButtonControl.Circle);
                QTE.Instance.SendCombo(ButtonControl.Circle);
            }
            else
            {

            }
        }
    }
    public void OnSquare(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                Debug.Log(ButtonControl.Square);
                QTE.Instance.SendCombo(ButtonControl.Square);
            }
            else
            {

            }
        }
    }
    public void OnTriangle(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                Debug.Log(ButtonControl.Triangle);
                QTE.Instance.SendCombo(ButtonControl.Triangle);
            }
            else
            {

            }
        }
    }

    public void SetQTE(bool state)
    {
        Debug.Log(state);
        inQTE = state;

    }
}
