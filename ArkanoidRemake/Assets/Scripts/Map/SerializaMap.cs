using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SerializeMap
{
    public int CurrentMapState { get; set; }
    public List<int> CurrentBlocks { get; set; }

    public SerializeMap(int currentMapState, List<int> currentBlocks)
    {
        CurrentMapState = currentMapState;
        CurrentBlocks = currentBlocks;
    }
}
