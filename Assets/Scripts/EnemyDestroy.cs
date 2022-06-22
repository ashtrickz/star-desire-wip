using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private GameObject score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            score.GetComponent<ScoreBar>().ChangeScore(-5);
            Destroy(collider.transform.parent.gameObject);
            
        }
    }
}
