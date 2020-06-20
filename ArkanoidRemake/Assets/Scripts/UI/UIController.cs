using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    }
}
