using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 5; 
    private Vector2 movementInput;

    // Start is called before the first frame update
    private void Start()
    {
        transform.Translate(new Vector3(0, 5, 0));
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);
    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
