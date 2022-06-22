using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public float damage = 10f;
    [SerializeField] private float shotTime = 5f;
    [SerializeField] private float shotSpeed = 5f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private ParticleSystem hitEffect;

    public float startTime;
    private bool flight;

    private void Start()
    {
        startTime = shotTime;
    }

    private void Update()
    {
        flight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().allowFlight;
        if (shotTime <= 0 && flight)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            projectile.GetComponent<PlayerProjectile>().GetData(damage, shotSpeed, hitEffect);
            shotTime = startTime;
        }
        else shotTime -= Time.deltaTime;
    }
}
