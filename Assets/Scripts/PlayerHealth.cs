using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;
    public float maxHealth;

    public CinemachineShake cinemachineShake;
    
    void Start()
    {
        maxHealth = health;
    }
    
    public void TakeDamage(float damage)
    {
        if (health > 1)
        {
            health -= damage;
            cinemachineShake.ShakeCamera(1,0.5f);
        }
        else SceneManager.LoadScene("SampleScene");
    }
}
