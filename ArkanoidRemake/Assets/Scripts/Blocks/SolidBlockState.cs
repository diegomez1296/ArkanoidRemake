using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidBlockState : BlockState
{
    public SolidBlockState(Block block) : base(block)
    {
    }

    protected override void Initialize()
    {
        block.HP = -1;  // -1 => infinity
        block.Score = 1000;
        block.Bonus = 100;
        //block.CurrentSprite.sprite = block.blockAsset.Sprites[0];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
