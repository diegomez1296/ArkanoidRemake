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

    public event Action OnGenerate;

    public void GenerateMap(bool isLoadingMap)
    {
        if (isLoadingMap)
        {
            foreach (var item in GameData.blocksOfMap)
            {
                item.gameObject.SetActive(true);
            }
        }
        else
        {
            OnGenerate?.Invoke();
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
            GenerateMap(false);
        }
    }
}
