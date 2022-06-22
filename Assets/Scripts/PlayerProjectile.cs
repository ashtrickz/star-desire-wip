using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public ParticleSystem hitEffect;
    public ParticleSystem shotEffect;

    public SpriteRenderer spriteRenderer;
    
    Vector2 projectile;
    [SerializeField] private float incline = 0;

    void Start()
    {
        //Instantiate(shotEffect, transform.position, Quaternion.identity);
    }
    
    private void Update()
    {
        projectile = Vector2.MoveTowards(transform.position, new Vector2(projectile.x + incline, projectile.y + 5), speed * Time.deltaTime);
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
        if (collision.gameObject.CompareTag("Player")) 
            Destroy(gameObject);
    }
    public void GetData(float weaponDamage, float weaponSpeed, ParticleSystem particle)
    {
        damage = weaponDamage;
        speed = weaponSpeed;
        hitEffect = particle;
    }

    public void GetIncline(float value) => incline = value;

    public void GetColor(int value)
    {
        if (value == 0)
            spriteRenderer.color = Color.white;
        else spriteRenderer.color = Color.magenta;
    }
    
}
