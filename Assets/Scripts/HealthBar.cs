using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerHealth health;
    [SerializeField] Image upperBar;
    [SerializeField] Image middleBar;
    [SerializeField] Image bottomBar;
    float speed = 2f;
    
    void Start()
    {     
        upperBar.fillAmount = middleBar.fillAmount = bottomBar.fillAmount = 1;
    }

    void Update()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        upperBar.fillAmount = health.health / health.maxHealth;
        middleBar.fillAmount = Mathf.Lerp(middleBar.fillAmount, upperBar.fillAmount, speed * Time.deltaTime);
    }
}
