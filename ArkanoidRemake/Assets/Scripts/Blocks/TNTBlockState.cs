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
        block.HP = 1;
        block.Score = 1500;
        block.BonusPercent = 70;
        //block.CurrentSprite.sprite = block.blockAsset.Sprites[0];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
