using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] int health = 40;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    EnemyBehavior enemyBehavior;


    public Animator animator;

    public Rigidbody2D rb;

    Vector2 movement;
    void Start()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();

    }

    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "Player")
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
