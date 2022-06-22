using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;
    public float maxHealth;

    void Start()
    {
        maxHealth = health;
    }
    
    public void TakeDamage(float damage)
    {
        if (health > 1)
            health -= damage;
        else SceneManager.LoadScene("SampleScene");
    }
}
