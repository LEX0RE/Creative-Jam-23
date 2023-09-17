using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    [SerializeField] public float speed = 5;
    [SerializeField] public float jumpForce = 500f;
    public bool idle = true;
    public bool mooveLeft = false;
    public bool moove = false;
    public bool OnAttack = false;
    public GameObject mesh;
    public Animator animator;
    private bool rotateApplied = false;
    private Vector2 movementInput;
    private bool inQTE = false;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

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
            if (!OnAttack && movementInput.y > -25)
            {
                transform.Translate(new Vector3(0, 0, movementInput.x) * speed * Time.deltaTime);
            }
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


        if (GetComponentInChildren<groundCheck>().isGrounded)
        {
            animator.SetBool("Jump", false);
            if (movementInput.x * 100 < 1 && movementInput.x * 100 > -1 & movementInput.y * 100 < 1)
            {
                idle = true;
                moove = false;
                mooveLeft = false;
                animator.SetBool("Run", false);
            }
            else if (movementInput.x * 100 > 1 || movementInput.x * 100 < -1)
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
        else
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
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
                QTE.Instance.SendCombo(ButtonControl.Cross);
            }
            else if (GetComponentInChildren<groundCheck>().isGrounded)
            {
                m_Rigidbody.AddForce(new Vector3(0f, jumpForce, 0f));
            }
        }
    }
    public void OnCircle(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                QTE.Instance.SendCombo(ButtonControl.Circle);
            }
            else
            {
                Debug.Log(ctx.control);
            }
        }
    }
    public void OnSquare(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                QTE.Instance.SendCombo(ButtonControl.Square);
            }
            else
            {
                if (GetComponentInChildren<groundCheck>().isGrounded)
                {
                    OnAttack = true;
                    animator.SetBool("Attack", true);
                }
            }
        }
    }
    public void OnTriangle(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                QTE.Instance.SendCombo(ButtonControl.Triangle);
            }
            else
            {
                Debug.Log(ctx.control);
            }
        }
    }

    public void SetQTE(bool state)
    {
        inQTE = state;

    }
    public void eventFinishfight()
    {
        animator.SetBool("Attack", false);
    }
}
