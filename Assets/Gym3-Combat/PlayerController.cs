using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    [SerializeField] public float speed = 5;
    private Vector2 movementInput;
    private bool inQTE = false;

    private void Start()
    {
        inQTE = false;
        transform.Translate(new Vector3(0, 5, 0));
    }

    private void Update()
    {
        if (!inQTE)
        {
            transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
    public void OnCross(InputAction.CallbackContext ctx)
    {
        if (inQTE)
        {
            Debug.Log(ctx.control);
        }
        else
        {
            Debug.Log(ctx.control);
        }
    }
    public void OnCircle(InputAction.CallbackContext ctx)
    {
        if (inQTE)
        {
            Debug.Log(ctx.control);
        }
        else
        {
            Debug.Log(ctx.control);
        }
    }
    public void OnSquare(InputAction.CallbackContext ctx)
    {
        if (inQTE)
        {
            Debug.Log(ctx.control);
        }
        else
        {
            Debug.Log(ctx.control);
        }
    }
    public void OnTriangle(InputAction.CallbackContext ctx)
    {
        if (inQTE)
        {
            Debug.Log(ctx.control);
        }
        else
        {
            Debug.Log(ctx.control);
        }
    }

    public void SetQTE(bool state)
    {
        inQTE = state;
    }
}
