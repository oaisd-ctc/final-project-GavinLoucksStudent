using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool awareOfPlayer { get; private set; }

    public Vector2 directionToPlayer { get; private set; }

    [SerializeField] private float awarenessDistance;

    private Transform player;

    public int health = 0;
    [SerializeField] private int maxHealth;

    PlayerMovement pm;

    public HealthBar healthBar;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        pm = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //health = PlayerPrefs.GetInt("healthAfterChange");
        //FindObjectOfType<HealthBar>().slider.value = health;
    }

    public void UpdateHealth(int damageValue)
    {
        health -= damageValue;
        healthBar.SetHealth(health);

        if (health > maxHealth)
        {
            health = maxHealth;

        }
        if (health <= 0)
        {
            health = 0;
            pm.Death();
            StartCoroutine(Wait());

            Debug.Log("Player Respawn");
        }
    }


    void Update()
    {

        //PlayerPrefs.SetInt("healthAfterChange", health);


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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<GameSessionController>().ProcessPlayerDeath();
    }
}