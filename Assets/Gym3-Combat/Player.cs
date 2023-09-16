using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam.SetActive(false);
        TakeDamage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TakeDamage()
    {
        cam.SetActive(true);
    }
}
