using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    [SerializeField] public float speed = 5;
    [SerializeField] public float jumpForce = 1000f;
    public bool idle = true;
    public bool mooveLeft = false;
    public bool moove = false;
    public bool OnAttack = false;
    public GameObject mesh;
    public Animator animator;
    public Vector3 startPosition;
    public static int nextId = 1;
    public int playerID;
    public LifePlayer playerLife;
    private int currentLife = 2;
    private bool lastChance = true;
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
        playerID = PlayerController.nextId++;
        currentLife = 2;
        transform.position = startPosition;
        gameObject.name = "Player" + this.playerID;
        lastChance = true;
        playerLife = GameObject.Find("Player" + this.playerID + "-Vie").GetComponent<LifePlayer>();
        playerLife.UpdatePlayerLife(currentLife);
        inQTE = false;
        transform.Translate(new Vector3(0, 5, 0));
        QTE.Instance.AddPlayer(this);
    }

    private void Update()
    {
        checkPlayerlife();
        if (!inQTE)
        {
            if (!OnAttack && !GetComponentInChildren<Animator>().GetBool("Death") && movementInput.y > -25)
            {
                transform.Translate(new Vector3(0, 0, movementInput.x) * speed * Time.deltaTime);
            }
            moovefunction();
        }
    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void moovefunction()
    {


        if (GetComponentInChildren<groundCheck>().isGrounded && !GetComponentInChildren<Animator>().GetBool("Death"))
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
                QTE.Instance.SendCombo(ButtonControl.Cross, this);
            }
            else if (GetComponentInChildren<groundCheck>().isGrounded && !GetComponentInChildren<Animator>().GetBool("Death") && !OnAttack)
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
                QTE.Instance.SendCombo(ButtonControl.Circle, this);
            }
        }
    }
    public void OnSquare(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (inQTE)
            {
                QTE.Instance.SendCombo(ButtonControl.Square, this);
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
                QTE.Instance.SendCombo(ButtonControl.Triangle, this);
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
    public void checkPlayerlife()
    {
        if (currentLife <= 0)
        {
            if (lastChance)
            {
                QTE.Instance.StartQTEEvent(this);
                lastChance = false;
                currentLife++;
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Death", true);
            }
        }
    }

    public void getDamage()
    {
        currentLife -= 1;
        playerLife.UpdatePlayerLife(currentLife);
    }
}
