using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public int weaponDamage = 20;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Slime>().DamageTook(weaponDamage);
        }
    }
}
