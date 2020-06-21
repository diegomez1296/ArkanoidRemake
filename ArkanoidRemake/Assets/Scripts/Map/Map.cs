using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class Map : ArkanoidObject
{
    public int BlocksToDestroy { get; set; }

    private int blocksDestroyed;
    public int BlocksDestroyed { get { return blocksDestroyed; }  set { blocksDestroyed++; CheckDestroyedBlocks(); } }

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

    private void CheckDestroyedBlocks()
    {
        Debug.Log("BlocksDestroyed: " + BlocksDestroyed + "/" + BlocksToDestroy);

        if (BlocksDestroyed >= BlocksToDestroy)
            GenerateMap(false);
    }
}
