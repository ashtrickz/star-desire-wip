using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{

    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI highscoreText;

    [SerializeField] private int highscore = 0;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void ChangeScore(int points)
    {
        score += points;
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
        text.text = "Score: " + score;
    }
}
