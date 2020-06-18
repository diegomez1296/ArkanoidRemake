using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public const int START_BALL_SPEED = 500;

    public static GameController Instance;

    public GameData Data { get; private set; }
    public SaveController Save { get; private set; }
    public AudioController Audio { get; private set; }

    private void Start()
    {
        Instance = this;

        Data = GetComponentInChildren<GameData>();
        Save = GetComponentInChildren<SaveController>();
        Audio = GetComponentInChildren<AudioController>();
    }


}
