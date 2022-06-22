using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    Vector2 player;
    Vector2 projectile;
    EnemyStats stats;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        damage = stats.damage;
    }

    private void Update()
    {
        projectile = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);
        transform.position = projectile;
        if (projectile == player)
        {
            Destroy(gameObject);
        }
        if (projectile == player*2)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Enemy") || !collision.gameObject.CompareTag("Projectile"))
            Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
