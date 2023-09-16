using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : Singleton<QTE>
{
    private List<Player> players = new List<Player>();
    // Start is called before the first frame update

    public void AddPlayer(Player p)
    {
        players.Add(p);
    }

    private void StartQTEEvent(Player p)
    {

    }
}
