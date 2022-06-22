using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    
    [SerializeField] private Button _pauseButton;
    public bool isPaused = false;
    public GameObject _pauseMenu;

    private void Awake()
    {
        _pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void OnClick()
    {
        if (!isPaused)
            Pause();
        else Resume();
    }

    void Pause()
    {
        _pauseButton.gameObject.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    void Resume()
    {
        _pauseButton.gameObject.SetActive(true);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Quit()
    {
        Debug.Log("Closing application...");
        Application.Quit();
    }

    public void ToMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
}
