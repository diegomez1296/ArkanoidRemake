using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class Map : ArkanoidObject
{
    public int BlocksToDestroy { get; set; }
    public int BlocksDestroyed { get; set; }

    public int Rows { get; set; }
    public int Columns { get; set; }
    public UnityEngine.Vector2 StartPosition { get; set; }

    public delegate void OnGenerate(SaveController.SaveGameBlock saveGameBlock);
    public event OnGenerate OnGenerated;

    public void GenerateMap(SaveController.SaveGameBlock saveGameBlock = null)
    {
        OnGenerated(saveGameBlock);
    }

    public void PrepareToGenerateMap(SaveController.SaveGameBlock saveGameBlock)
    {
        GameController.Instance.Data.ClearDataBlocks();

        if (saveGameBlock == null)
        {
            BlocksToDestroy = 0;
            BlocksDestroyed = 0;
        }
        else
        {
            BlocksToDestroy = saveGameBlock.BlocksOfMap.BlocksToDestroy;
            BlocksDestroyed = saveGameBlock.BlocksOfMap.BlocksDestroyed;
        }
    }

    public void CheckDestroyedBlocks()
    {
        if (BlocksToDestroy <= 0) return;

        Debug.Log("BlocksDestroyed: " + BlocksDestroyed + "/" + BlocksToDestroy);

        if (BlocksDestroyed >= BlocksToDestroy)
        {
            BlocksToDestroy = 0;
            BlocksDestroyed = 0;
            GenerateMap(null);
        }
    }
}
