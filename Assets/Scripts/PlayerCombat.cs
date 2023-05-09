using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    [SerializeField] AudioClip attackSfx;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            AudioSource.PlayClipAtPoint(attackSfx, Camera.main.transform.position);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }





}
