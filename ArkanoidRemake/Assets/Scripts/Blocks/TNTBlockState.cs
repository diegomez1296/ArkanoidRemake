using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTBlockState : BlockState
{
    public TNTBlockState(Block block) : base(block)
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
