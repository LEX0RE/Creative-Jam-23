using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private List<Sprite> buttons;
    [SerializeField] private List<GameObject> slots;
    public GameObject canvas;
    public GameObject buttonContainer;
    private bool eventStarted = false;
    private bool result = false;
    private List<Player> players = new List<Player>();
    private List<ButtonControl> combos = new List<ButtonControl>();
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
            foreach (PlayerController player in players)
            {
                player.SetQTE(true);
            }
            StartCoroutine(ShowLastChance(p));
        }
    }

    IEnumerator ShowLastChance(Player p)
    {
        MainCamera.Instance.MoveToPlayer(p);
        GenerateCombo();
        yield return new WaitForSeconds(timeBeforeCanvas);
        foreach (ButtonControl button in combos)
        {
            Debug.Log(button);
        }
        ShowCombos();
        canvas.SetActive(true);
        StartCoroutine(StartCombo());
    }

    IEnumerator StartCombo()
    {
        yield return new WaitForSeconds(maxTime);
        if (combos.Count > 0)
        {
            StartCoroutine(EndCombo());
        }
    }

    IEnumerator EndCombo()
    {
        if (combos.Count > 0)
        {
            Debug.Log("Game End");
            ClearCombos();
        }
        foreach (PlayerController player in players)
        {
            player.SetQTE(false);
        }
        canvas.SetActive(false);
        MainCamera.Instance.clearView();
        yield return new WaitForSeconds(timeBeforeCanvas);
    }

    public void SendCombo(ButtonControl b)
    {
        Debug.Log(b);
        if (combos.Count > 0 && combos[0] == b)
        {
            combos.RemoveAt(0);
            if (combos.Count == 0)
            {
                StartCoroutine(EndCombo());
            }
            else
            {
                ShowCombos();
            }
        }
    }

    public void Reset()
    {
        players.Clear();
    }

    public void ShowCombos()
    {
        while (buttonContainer.transform.childCount > 0)
        {
            DestroyImmediate(buttonContainer.transform.GetChild(0).gameObject);
        }
        for (int i = 0; i < combos.Count; i++)
        {
            slots[i].GetComponent<Image>().sprite = buttons[(int)combos[i]];
            Color tempColor = slots[i].GetComponent<Image>().color;
            tempColor.a = 1f;
            slots[i].GetComponent<Image>().color = tempColor;
        }
        for (int i = combos.Count; i < maxSequence; i++)
        {
            Color tempColor = slots[i].GetComponent<Image>().color;
            tempColor.a = 0f;
            slots[i].GetComponent<Image>().color = tempColor;
        }
    }

    private void ClearCombos()
    {
        while (buttonContainer.transform.childCount > 0)
        {
            DestroyImmediate(buttonContainer.transform.GetChild(0).gameObject);
        }
        combos.Clear();
    }

    private void GenerateCombo()
    {
        int sequenceNumber = Random.Range(minSequence, maxSequence);
        for (int i = 0; i < sequenceNumber; i++)
        {
            int button = Random.Range(0, Enum.GetNames(typeof(ButtonControl)).Length);
            combos.Add((ButtonControl)button);
        }
    }
}
