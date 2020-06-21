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
        Plank.ball.IsRunning = false;
    }

    public SerializeMap PrepareMapToSave()
    {
        List<int> blockIDs = new List<int>();

        foreach (var item in GameData.blocksOfMap)
        {
            blockIDs.Add(item.gameObject.activeSelf ? GameController.Instance.BlockStateToInt((BlockState)item.CurrentState) : -1);
        }

        return new SerializeMap(GameController.Instance.MapStateToInt((MapState)Map.CurrentState), blockIDs, Map.BlocksToDestroy, Map.BlocksDestroyed);
    }
}

[Serializable]
public class SerializeMap
{
    public int CurrentMapState { get; set; }
    public List<int> CurrentBlocks { get; set; }
    public int BlocksToDestroy { get; set; }
    public int BlocksDestroyed { get; set; }

    public SerializeMap(int currentMapState, List<int> currentBlocks, int blocksToDestroy, int blocksDestroyed)
    {
        CurrentMapState = currentMapState;
        CurrentBlocks = currentBlocks;
        BlocksToDestroy = blocksToDestroy;
        BlocksDestroyed = blocksDestroyed;
    }
}
