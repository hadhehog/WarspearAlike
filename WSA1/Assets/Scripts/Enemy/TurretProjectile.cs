using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public int damage = 40;
    // int for damage
    public float health;
    public float speed = 20f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
     {
         enemyHealth enemy = hitInfo.GetComponent<enemyHealth>();
         // Grabs the enemyHealth script component
         if (enemy != null)
         {
             enemy.TakeDamage(damage);
             Destroy(gameObject);
         }

     }

}
