﻿using UnityEngine;
using System.Collections;

public abstract class BlockState
{
    protected Block block;

    public BlockState(Block block)
    {
        this.block = block;
        Initialize();
    }

    protected abstract void Initialize(); //This method describe values of our Block

    protected abstract void OnHit(); //This method describe what will happen after hit
}
