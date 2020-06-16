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
        block.HP = 3;
        block.Score = 300;
        block.Bonus = 50;
        //block.CurrentSprite.sprite = block.blockAsset.Sprites[0];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
