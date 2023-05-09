using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] int health = 60;
    [SerializeField] private int attackDamage = 20;
    [SerializeField] private float attackSpeed = .3f;
    private float canAttack;
    EnemyBehavior enemyBehavior;


    public Animator animator;

    public Rigidbody2D rb;

    Vector2 movement;

    PlayerHealth playerHealth;
    void Start()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "Player" && playerHealth.health > 0)
        {
            if (attackSpeed <= canAttack)
            {
                animator.SetTrigger("Attack");
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                Debug.Log("Player Hit " + attackDamage);
                canAttack = 0;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    public void DamageTook(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {

            enemyBehavior.deathSpeed(gameObject);
        }
    }

}
