using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Atira
{
    
    public float speed;
    public Transform Enemy;
    private Vector2 Target;
    private void Start()
    {

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Enemy.position, speed * Time.deltaTime);
    if (transform.position == Enemy.position)
        {
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}