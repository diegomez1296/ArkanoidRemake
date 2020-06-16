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
        block.HP = 1;
        block.Score = 100;
        block.Bonus = 30;
        //block.CurrentSprite.sprite = block.blockAsset.Sprites[0];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
