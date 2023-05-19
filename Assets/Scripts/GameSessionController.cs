using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameSessionController : MonoBehaviour
{



    [SerializeField] public int health;

    [SerializeField] public int maxHealth;

    [SerializeField] public Slider slider;
    PlayerMovement pm;

    void Awake()
    {


        int numGameSessions = FindObjectsOfType<GameSessionController>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }


    public void ProcessPlayerDeath()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void SetMaxHealth()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth()
    {
        slider.value = health;
    }

    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        health = maxHealth;
        SetMaxHealth();
    }

    public void UpdateHealth(int damageValue)
    {
        health -= damageValue;
        SetHealth();

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




    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        ProcessPlayerDeath();
    }

}
