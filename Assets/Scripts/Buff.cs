using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Buff : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float effectStrength = 5f;
    [SerializeField] private effectType effectList = new effectType();
    [SerializeField] private PlayerHealth _playerHealth;
    
    private Weapon _weapon;
    private Collider2D _collider;
    private bool pickedUp = false;
    private Vector2 position;

    private SpriteRenderer _spriteRenderer;
    public enum effectType
    {
        Heal,
        Speed,
        Power
    }

    private void Start()
    {
        position = transform.position;
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        EffectRandomizer();
        StartCoroutine(SelfDestroy());
    }

    private void Update()
    {
        _weapon = GameObject.FindObjectOfType<Weapon>();
        position.y -= 0.5f * Time.deltaTime;
        transform.position = position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickedUp = true;
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
            if (effectList == effectType.Heal)
            {
                if (_playerHealth.health + effectStrength > _playerHealth.maxHealth)
                    _playerHealth.health = _playerHealth.maxHealth;
                else _playerHealth.health += effectStrength;
                Destroy(gameObject);
            }
            if (effectList == effectType.Speed)
                StartCoroutine(SpeedBuff());
            if (effectList == effectType.Power)
                StartCoroutine(Power());
        }
    }

    private void EffectRandomizer()
    {
        int number = UnityEngine.Random.Range(1, 4);
        switch (number)
        {
            case 1:
                effectList = effectType.Heal;
                _spriteRenderer.color = Color.green;
                break;
            case 2:
                effectList = effectType.Speed;
                _spriteRenderer.color = Color.cyan;
                break;
            case 3:
                effectList = effectType.Power;
                _spriteRenderer.color = Color.red;
                break;
        }
    }
    
    IEnumerator SpeedBuff()
    {
        _weapon.startTime /= effectStrength/2;
        yield return new WaitForSeconds(duration);
        Debug.Log("time is off");
        _weapon.startTime *= effectStrength/2;
        Destroy(gameObject);
    }

    IEnumerator Power()
    {
        _weapon.damage *= effectStrength/2;
        yield return new WaitForSeconds(duration);
        Debug.Log("time is off");
        _weapon.damage /= effectStrength/2;
        Destroy(gameObject);
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5f);
        if (!pickedUp)
            Destroy(gameObject);
    }
}
