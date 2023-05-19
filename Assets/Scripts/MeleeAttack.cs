using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public int weaponDamage = 20;


    PlayerManager pm;

    void Start()
    {



        pm = GetComponent<PlayerManager>();

    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().DamageTook(weaponDamage);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Slime>().DamageTook(weaponDamage);
        }
        else if (other.CompareTag("Orb"))
        {
            other.GetComponent<OrbManager>().DamageTook(weaponDamage);
        }

    }


}
