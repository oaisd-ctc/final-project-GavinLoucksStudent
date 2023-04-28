using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private int health = 0;
    [SerializeField] private int maxHealth;

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

    }
}
