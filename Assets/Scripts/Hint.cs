using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Hint : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private EnemySpawner enemySpawner;
    
    void Start() => playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    
    void Update()
    {
        if (playerMovement.allowFlight)
        {
            gameObject.SetActive(false);
            enemySpawner.SpawnStart();
        }
    }
}
