using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool awareOfPlayer { get; private set; }

    public Vector2 directionToPlayer { get; private set; }

    [SerializeField] private float awarenessDistance;

    private Transform player;

    private int health = 0;
    [SerializeField] private int maxHealth;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(int mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0;
            Debug.Log("Player Respawn");
        }
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
