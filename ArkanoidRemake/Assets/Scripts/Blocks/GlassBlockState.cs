using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlockState : BlockState
{
    public GlassBlockState(Block block) : base(block)
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
