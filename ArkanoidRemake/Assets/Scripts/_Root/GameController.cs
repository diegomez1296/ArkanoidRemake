using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameController Instance => this;

    public GameData Data { get; private set; }
    public SaveController Save { get; private set; }
    public AudioController Audio { get; private set; }

    private void Start()
    {
        Data = GetComponentInChildren<GameData>();
        Save = GetComponentInChildren<SaveController>();
        Audio = GetComponentInChildren<AudioController>();
    }


}
