using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class FireBall : MonoBehaviour
{
    [SerializeField] float fireballSpeed = 5f;
    [SerializeField] int fireballDamage = 30;
    public float rotateSpeed = 200f;
    float xSpeed;

    Rigidbody2D rb;
    Boss b;
    GameSessionController gsc;


    void Start()
    {

        //if (target == null)
        //  {
        //     Debug.Log("Hi");
        ///     pm = GameObject.Find("Karthur").GetComponent<PlayerManager>();
        //    target = pm.transform;
        // }

        rb = GetComponent<Rigidbody2D>();
        b = FindObjectOfType<Boss>();
        gsc = FindObjectOfType<GameSessionController>();
        xSpeed = b.transform.localScale.x * -fireballSpeed;
    }


    void FixedUpdate()
    {
        //  Vector2 direction = (Vector2)target.position - rb.position;

        // direction.Normalize();
        //
        // float rotateAmount = Vector3.Cross(direction, transform.up).z;

        // rb.angularVelocity = -rotateAmount * rotateSpeed;

        // rb.velocity = transform.up * fireballSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gsc.UpdateHealth(fireballDamage);
            Destroy(gameObject);
        }

    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    // }
}
