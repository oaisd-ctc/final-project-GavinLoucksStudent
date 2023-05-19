using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool awareOfPlayer { get; private set; }

    public Vector2 directionToPlayer { get; private set; }

    [SerializeField] private float awarenessDistance;

    private Transform player;

    PlayerMovement pm;



    GameSessionController gsc;

    private void Awake()
    {


        player = FindObjectOfType<PlayerMovement>().transform;
        pm = GetComponent<PlayerMovement>();
        gsc = FindObjectOfType<GameSessionController>();
    }



    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= awarenessDistance)
        {
            awareOfPlayer = true;
        }
        else
        {
            awareOfPlayer = false;
        }
    }


}