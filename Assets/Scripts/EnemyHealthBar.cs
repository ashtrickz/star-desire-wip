using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyStats stats;
    public Slider healthBar;
    public GameObject enemy;

    private void Start()
    {
        healthBar.maxValue = healthBar.value = stats.health;
    }

    private void Update()
    {
        healthBar.value = stats.health;
        healthBar.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 0.6f);
        if(enemy==null)
        {
            Destroy(gameObject);
        }
    }

    private void HealthUpdate(float health)
    {
        healthBar.value = health;
        
    }
}
