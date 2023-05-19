using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform spawnPoint;

    PlayerManager player;


    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        player.transform.position = spawnPoint.position;
    }

}
