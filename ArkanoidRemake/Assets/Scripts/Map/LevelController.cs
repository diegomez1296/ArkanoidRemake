using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public Map Map { get; private set; }
    public Plank Plank { get; private set; }

    private void Awake() => Instance = this;

    private void Start()
    {
        Map = GetComponentInChildren<Map>();
        Plank = GetComponentInChildren<Plank>();
    }
}
