using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBlockState : BlockState
{
    public DefaultBlockState(Block block) : base(block)
    {
    }

    protected override void Initialize()
    {
        
    }

    protected override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
