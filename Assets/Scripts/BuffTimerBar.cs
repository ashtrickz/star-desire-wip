using System;
using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {     
        frontBar.fillAmount = 1;
        frontBar.gameObject.SetActive(false);
        backBar.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isStarted)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / speed;
            frontBar.fillAmount = Mathf.Lerp(frontBar.fillAmount, 0, Mathf.SmoothStep(0, 1 ,percentageComplete));
        }
    }
    
    public void TimerStart(float value)
    {
        isStarted = true;
        elapsedTime = 0;
        speed = value * 10;
        frontBar.fillAmount = 1;
        frontBar.gameObject.SetActive(true);
        backBar.gameObject.SetActive(true);
    }

    public void TimerEnd()
    {
        isStarted = false;
        frontBar.gameObject.SetActive(false);
        backBar.gameObject.SetActive(false);
    }
    
}
