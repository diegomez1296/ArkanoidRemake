﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public PausePanel pausePanel;
    [Space]
    [SerializeField] private TextMeshProUGUI highscore;
    [SerializeField] private TextMeshProUGUI currscore;
    [SerializeField] private GameObject lifesParent;

    private bool isMoreThanHighscore = false;
    private Color highscoreColor;
    private Color currentScoreColor;

    private Image[] lifes;

    private void Start()
    {
        highscoreColor = highscore.color;
        currentScoreColor = currscore.color;
        lifes = lifesParent.GetComponentsInChildren<Image>();
        pausePanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.gameObject.activeSelf) pausePanel.ShowPause();
            else pausePanel.HidePause();

            pausePanel.CheckPauseOptions();
        }
    }

    public void SetHighScore()
    {
        highscore.text = GameData.HighScore + "";
    }

    public void SetDefaultScoreColors()
    {
        isMoreThanHighscore = false;
        currscore.color = currentScoreColor; 
        highscore.color = highscoreColor;
    }

    public void SetCurrentScore()
    {
        currscore.text = GameData.CurrentScore + "";

        if(GameData.CurrentScore > GameData.HighScore)
        {
            GameData.HighScore = GameData.CurrentScore;
            if (!isMoreThanHighscore)
            {
                currscore.color = highscoreColor;
                highscore.color = currentScoreColor;
                isMoreThanHighscore = true;
            }
        }
    }

    internal void SetHP(float hp)
    {
        for (int i = 0; i < lifes.Length; i++)
            lifes[i].gameObject.SetActive(i < hp);
    }
}