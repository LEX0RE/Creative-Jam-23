using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        // Set the start spawn position of the player using the location at the associated element into the array.
        playerInput.gameObject.GetComponent<PlayerController>().startPosition = spawnLocations[playerInput.playerIndex].transform.position;
    }
}
