using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class Map : ArkanoidObject
{
    public int BlocksToDestroy { get; set; }

    public int Rows { get; set; }
    public int Columns { get; set; }
    public UnityEngine.Vector2 StartPosition { get; set; }

    public delegate void OnGenerate(SaveController.SaveGameBlock saveGameBlock);
    public event OnGenerate OnGenerated;

    public void GenerateMap(SaveController.SaveGameBlock saveGameBlock = null)
    {
        OnGenerated(saveGameBlock);
    }

    public void CheckDestroyedBlocks()
    {
        BlocksToDestroy = 0;

        foreach (var item in GameData.blocksOfMap)
        {
            if (item.gameObject.activeSelf && !typeof(SolidBlockState).IsInstanceOfType(item) && item.HP > 0 && item.HP < 100)
                BlocksToDestroy++;
        }

        //Debug.Log("BlocksToDestroy: " + BlocksToDestroy);

        if (BlocksToDestroy <= 0)
        {
            LevelController.Instance.Plank.LoseLife();
            LevelController.Instance.Plank.HP++;
            GenerateMap(null);
        }
    }
}
