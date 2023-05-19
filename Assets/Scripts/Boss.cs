using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] int bossHealth;



    public Animator animator;

    [SerializeField] private int attackDamage = 30;
    [SerializeField] private float attackSpeed = 1;



    EnemyBehavior eb;

    private float canAttack;

    GameSessionController gsc;


    [SerializeField] PlayerManager pm;


    [SerializeField] GameObject fireball;
    [SerializeField] Transform fireballSpawn;
    void Start()
    {

        eb = FindObjectOfType<EnemyBehavior>();
        gsc = FindObjectOfType<GameSessionController>();


    }


    void Update()
    {
        if (pm == null)
        {
            pm = FindObjectOfType<PlayerManager>();
        }
    }

    public void CanBeAttacked()
    {
        if (pm.orbsDestroyed == 3)
        {
            pm.canBeAttacked = true;
        }
    }

    public void DamageTook(int damage)
    {
        bossHealth -= damage;
        Debug.Log(bossHealth);
        if (bossHealth <= 0)
        {
            animator.SetTrigger("Dead");
            eb.deathSpeed(gameObject);
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "Player" && gsc.health > 0)
        {
            if (attackSpeed <= canAttack)
            {
                animator.SetTrigger("Attack");
                Instantiate(fireball, fireballSpawn.position, transform.rotation);

                canAttack = 0;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
