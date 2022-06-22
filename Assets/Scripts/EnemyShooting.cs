using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float startTimeBtwShots;
    private float timeBtwShots;
    public GameObject shot;
    public GameObject gun;
    public EnemyStats stats;

    private void Start()
    {
        startTimeBtwShots = timeBtwShots = stats.shootSpeed;
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(shot, gun.transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
            timeBtwShots -= Time.deltaTime;
    }
}
