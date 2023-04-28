using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;

    public float speed;
    public float distanceBetween;
    private float distance;



    void Start()
    {

    }

    void Update()
    {

        flipSprite();


        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();




        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }

    }

    public void deathSpeed(GameObject objectToDestroy)
    {

        Destroy(objectToDestroy);
    }

    public void flipSprite()
    {
        if (enemy.transform.position.x < player.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (enemy.transform.position.x > player.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
        }
    }



}
