using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Buff : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float effectStrength = 5f;
    [SerializeField] private effectType effectList = new effectType();
    private PlayerHealth _playerHealth;
    private BuffTimerBar buffTimerBar;
    
    private Weapon _weapon;
    private WeaponChanger weaponChanger;
    private Collider2D _collider;
    private bool pickedUp = false;
    private Vector2 position;

    [SerializeField] private float weaponChangeDuration = 10f;
    [SerializeField] private float weaponEffectDuration = 5f;

    private SpriteRenderer _spriteRenderer;
    public enum effectType
    {
        Heal,
        Speed,
        Power,
        SecondWeapon
    }

    private void Start()
    {
        position = transform.position;
        buffTimerBar = GameObject.FindObjectOfType<BuffTimerBar>();
        weaponChanger = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponChanger>();
        _weapon = GameObject.FindObjectOfType<Weapon>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        EffectRandomizer();
        StartCoroutine(SelfDestroy());
    }

    private void Update()
    {
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
            if (effectList == effectType.SecondWeapon)
                StartCoroutine(SecondWeapon());
        }
    }

    private void EffectRandomizer()
    {
        int number = UnityEngine.Random.Range(1, 5);
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
            case 4:
                effectList = effectType.SecondWeapon;
                _spriteRenderer.color = Color.yellow;
                break;
        }
    }

    IEnumerator SpeedBuff()
    {
        duration = weaponEffectDuration;
        _weapon.startTime /= effectStrength/2;
        buffTimerBar.TimerStart(duration);
        yield return new WaitForSeconds(duration);
        buffTimerBar.TimerEnd();
        Debug.Log("time is off");
        _weapon.startTime *= effectStrength/2;
        Destroy(gameObject);
    }

    IEnumerator Power()
    {
        duration = weaponEffectDuration;
        _weapon.damage *= effectStrength/2;
        buffTimerBar.TimerStart(duration);
        yield return new WaitForSeconds(duration);
        buffTimerBar.TimerEnd();
        Debug.Log("time is off");
        _weapon.damage /= effectStrength/2;
        Destroy(gameObject);
    }

    IEnumerator SecondWeapon()
    {
        duration = weaponChangeDuration;
        weaponChanger.ChangeWeapon();
        buffTimerBar.TimerStart(duration);
        yield return new WaitForSeconds(duration);
        buffTimerBar.TimerEnd();
        weaponChanger.ChangeWeapon();
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(duration);
        if (!pickedUp)
            Destroy(gameObject);
    }
    
}
