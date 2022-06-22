using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordersDisabler : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerProjectile>())
            Destroy(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerProjectile>())
            Destroy(other.gameObject);
    }
}
