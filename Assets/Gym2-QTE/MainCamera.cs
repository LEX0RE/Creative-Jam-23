using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCamera : Singleton<MainCamera>
{
    [SerializeField] public static Vector3 defaultPosition = new(0.0f, 0.5f, -12.0f);
    [SerializeField] public float transitionSpeed = 10f;
    [SerializeField] public float distanceToStop = 0.0001f;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        clearView();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) > distanceToStop)
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * transitionSpeed);
    }

    public void MoveToPlayer(Player targetPlayer)
    {
        target = targetPlayer.gameObject.transform.position + new Vector3(2, 1, -5);
    }

    public void clearView()
    {
        target = defaultPosition;
    }
}