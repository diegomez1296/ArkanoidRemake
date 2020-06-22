using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    
    public MenuUI Menu { get; private set; }
    public GameUI Game { get; private set; }

    private void Awake() => Instance = this;

    private void Start()
    {
        Menu = GetComponentInChildren<MenuUI>();
        Game = GetComponentInChildren<GameUI>();

        Game.gameObject.SetActive(false);
    }

    internal void SetGameUI()
    {
        Game.SetCurrentScore();
        Game.SetHighScore();
        Game.SetDefaultScoreColors();
        Game.SetHP(LevelController.Instance.Plank.HP);
        Game.pausePanel.HidePause();
        Menu.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
    }

    public void SetMenuUI()
    {
        GameController.Instance.CreateSave(Game.pausePanel.IsGameOver);
        Game.pausePanel.IsGameOver = false;
        Game.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
    }
}
