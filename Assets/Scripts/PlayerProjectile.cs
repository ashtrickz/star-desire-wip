using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public ParticleSystem hitEffect;

    Vector2 projectile;

    private void Update()
    {
        projectile = Vector2.MoveTowards(transform.position, new Vector2(projectile.x, projectile.y + 5), speed * Time.deltaTime);
        transform.position = projectile;
        if (projectile.y > 5 || projectile.x > 3)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            Instantiate(hitEffect, transform.position, Quaternion.LookRotation(Vector2.down));
            DamagePopup.Create(transform.position, damage);
        }
        if (collision.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
    public void GetData(float weaponDamage, float weaponSpeed, ParticleSystem particle)
    {
        damage = weaponDamage;
        speed = weaponSpeed;
        hitEffect = particle;
    }
}
