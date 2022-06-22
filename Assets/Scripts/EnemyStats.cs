using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float health = 5;
    [SerializeField] public float damage = 1;
    [SerializeField] public float shootSpeed = 1f;
    [SerializeField] private GameObject _buff;
    private GameObject score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
    }

    private void Update()
    {
        
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
            score.GetComponent<ScoreBar>().ChangeScore(5);
            if (UnityEngine.Random.Range(1, 4) <= 1)
                Instantiate(_buff, transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(float damage) => health -= damage;
}
