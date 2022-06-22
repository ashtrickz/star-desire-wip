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

    private WeaponChanger weaponChanger;
    private PlayerProjectile playerProjectile;
    
    public float startTime;
    private bool flight;

    private void Start()
    {
        startTime = shotTime;
        weaponChanger = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponChanger>();
        playerProjectile = projectile.GetComponent<PlayerProjectile>();
    }

    private void Update()
    {
        flight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().allowFlight;
        if (shotTime <= 0 && flight)
        {
            playerProjectile.GetData(damage, shotSpeed, hitEffect);
            if (weaponChanger.selectedWeapon == 1)
            {
                for (int i = -3; i <= 3; i+=3)
                {
                    playerProjectile.GetIncline(i);
                    Instantiate(projectile, transform.position, Quaternion.identity);
                }
            }
            else
            {
                playerProjectile.GetIncline(0);
                Instantiate(projectile, transform.position, Quaternion.identity);
            }
            shotTime = startTime;
        }
        else shotTime -= Time.deltaTime;
    }
}
