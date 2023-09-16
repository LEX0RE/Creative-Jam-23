using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ButtonControl
{
    Cross,
    Square,
    Triangle,
    Circle
}

public class QTE : Singleton<QTE>
{
    [SerializeField] public int minSequence = 2;
    [SerializeField] public int maxSequence = 5;
    [SerializeField] public float maxTime = 10;
    [SerializeField] public float timeBeforeCanvas = 0.1f;
    public GameObject canvas;
    private bool eventStarted = false;
    private bool result = false;
    private List<Player> players = new List<Player>();
    private Stack<ButtonControl> inputs = new Stack<ButtonControl>();
    public void Start()
    {
        canvas.SetActive(false);
    }

    public void AddPlayer(Player p)
    {
        players.Add(p);
    }

    public void StartQTEEvent(Player p)
    {
        if (!eventStarted)
        {
            result = false;
            eventStarted = true;
            StartCoroutine(ShowLastChance(p));
        }
    }

    IEnumerator ShowLastChance(Player p)
    {
        MainCamera.Instance.MoveToPlayer(p);
        generateCombo();
        yield return new WaitForSeconds(timeBeforeCanvas);
        foreach (ButtonControl button in inputs)
        {
            Debug.Log(button);
        }
        foreach (PlayerController player in players)
        {
            player.SetQTE(true);
        }
        canvas.SetActive(true);
        StartCoroutine(StartCombo());
    }

    IEnumerator StartCombo()
    {
        yield return new WaitForSeconds(maxTime);
        if (inputs.Count > 0)
        {
            StartCoroutine(EndCombo());
        }
    }

    IEnumerator EndCombo()
    {
        if (inputs.Count > 0)
        {
            Debug.Log("Game End");
            inputs.Clear();
        }
        foreach (PlayerController player in players)
        {
            player.SetQTE(false);
        }
        MainCamera.Instance.clearView();
        yield return new WaitForSeconds(timeBeforeCanvas);
        canvas.SetActive(false);
    }

    public void SendCombo(ButtonControl b)
    {
        if (inputs.Count > 0 && inputs.Peek() == b)
        {
            inputs.Pop();
        }
    }

    public void Reset()
    {
        players.Clear();
    }

    private void generateCombo()
    {
        int sequenceNumber = Random.Range(minSequence, maxSequence);
        for (int i = 0; i < sequenceNumber; i++)
        {
            int button = Random.Range(0, Enum.GetNames(typeof(ButtonControl)).Length);
            inputs.Push((ButtonControl)button);
        }
    }
}
