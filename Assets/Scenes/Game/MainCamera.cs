using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class MainCamera : Singleton<MainCamera>
{
    [SerializeField] public static Vector3 defaultPosition = new(0.0f, 0.5f, -18.8f);
    [SerializeField] public float transitionSpeed = 10f;
    [SerializeField] public float distanceToStop = 0.0001f;
    private Player target;
    private bool reset = true;
    // Start is called before the first frame update
    void Start()
    {
        clearView();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GetVectTarget()) > distanceToStop)
        {
            transform.position = Vector3.Lerp(transform.position, GetVectTarget(), Time.deltaTime * transitionSpeed);
        }
    }

    public void MoveToPlayer(Player targetPlayer)
    {
        reset = false;
        target = targetPlayer;
    }

    public void clearView()
    {
        reset = true;
    }

    private Vector3 GetVectTarget()
    {
        if (reset || !target)
        {
            return defaultPosition;
        }
        else
        {
            return target.gameObject.transform.position + new Vector3(2, 1, -6);
        }
    }
}
