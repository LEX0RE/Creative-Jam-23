using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQTEComponent : MonoBehaviour
{
    public bool completed = false;

    void Update()
    {
        if (completed)
        {
            Destroy(gameObject);
        }
    }
}
