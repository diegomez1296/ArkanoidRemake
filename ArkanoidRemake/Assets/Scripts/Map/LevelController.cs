using System;
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

        Plank.gameObject.SetActive(false);
    }

    public void ActivePlayer(float hp)
    {
        Plank.HP = hp;
        Plank.gameObject.SetActive(true);
        Plank.ball[0].IsRunning = false;
    }

    public SerializeMap PrepareMapToSave()
    {
        List<int> blockIDs = new List<int>();

        foreach (var item in GameData.blocksOfMap)
        {
            blockIDs.Add(item.gameObject.activeSelf ? GameController.Instance.BlockStateToInt((BlockState)item.CurrentState) : -1);
        }

        return new SerializeMap(GameController.Instance.MapStateToInt((MapState)Map.CurrentState), blockIDs);
    }
}
