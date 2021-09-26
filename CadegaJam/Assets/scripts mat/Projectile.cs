using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
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
            Debug.Log("aqui");
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ali  :" + other.name);
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Debug.Log("destroi");
        Destroy(gameObject);
    }
}