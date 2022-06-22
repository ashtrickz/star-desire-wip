using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;
    [SerializeField]
    private float enemySpawnInterval = 3.5f;
    
    void Start()
    {
        StartCoroutine(spawnEnemy( enemySpawnInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(enemySpawnInterval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2f, 2f), 5.5f, 0f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
