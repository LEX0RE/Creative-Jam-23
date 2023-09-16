using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : Singleton<QTE>
{
    [SerializeField] public int maxSequence = 5;
    [SerializeField] public int maxTime = 10;
    [SerializeField] public int timeBeforeCanvas = 1;
    public GameObject canvas;
    private bool eventStarted = false;
    private bool result = false;
    private List<Player> players = new List<Player>();
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
            MainCamera.Instance.MoveToPlayer(p);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeBeforeCanvas);
        canvas.SetActive(true);
        yield return new WaitForSeconds(maxTime);
        foreach (PlayerController player in players)
        {
            player.SetQTE(true);
        }
    }

    public void Reset()
    {
        players.Clear();
    }
}
