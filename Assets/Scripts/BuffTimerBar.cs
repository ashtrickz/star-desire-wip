using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuffTimerBar : MonoBehaviour
{
    Buff buff;
    [SerializeField] private Image frontBar;
    [SerializeField] private Image backBar;

    private float speed = 5f;
    private float elapsedTime;
    private bool isStarted = false;
    private bool isActive = false;
    
    void Start()
    {     
        frontBar.fillAmount = 1;
        frontBar.gameObject.SetActive(false);
        backBar.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        isActive = false;
        backBar.gameObject.SetActive(false);
        if (isStarted)
        {
            isActive = true;
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / speed;
            frontBar.fillAmount = Mathf.Lerp(frontBar.fillAmount, 0, Mathf.SmoothStep(0, 1 ,percentageComplete));
            backBar.gameObject.SetActive(true);
        }
    }
    
    public void TimerStart(float value)
    {
        TimerEnd();
        isStarted = true;
        elapsedTime = 0;
        speed = value * 10;
        frontBar.fillAmount = 1;
        frontBar.gameObject.SetActive(true);
    }

    public void TimerEnd()
    {
        if (!isActive)
        {
            isStarted = false;
            frontBar.gameObject.SetActive(false);
        }
    }
    
}
