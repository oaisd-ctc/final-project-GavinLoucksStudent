using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [SerializeField] int orbHealth = 100;

    PlayerManager pm;

    EnemyBehavior eb;

    Boss boss;

    MeleeAttack ma;

    void Start()
    {
        eb = FindObjectOfType<EnemyBehavior>();
        pm = FindObjectOfType<PlayerManager>();
        boss = FindObjectOfType<Boss>();
    }


    void Update()
    {

    }

    public void DamageTook(int damage)
    {
        orbHealth -= damage;
        Debug.Log(orbHealth);
        if (orbHealth <= 0)
        {
            eb.deathSpeed(gameObject);
            pm.orbsDestroyed++;
            boss.CanBeAttacked();
        }
    }
}
