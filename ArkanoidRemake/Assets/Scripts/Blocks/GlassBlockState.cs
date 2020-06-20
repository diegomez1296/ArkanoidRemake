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
        block.maxHP = block.HP;
        block.Score = 300;
        block.BonusPercent = 50;
        block.CurrentSprite.sprite = GameController.Instance.Data.blockSprites[5];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        if (block.HP / block.maxHP <= 0.4f) block.CurrentSprite.sprite = GameController.Instance.Data.blockSprites[7];
        else if (block.HP / block.maxHP <= 0.7f) block.CurrentSprite.sprite = GameController.Instance.Data.blockSprites[6];

        block.DestroyBlock();
    }
}
