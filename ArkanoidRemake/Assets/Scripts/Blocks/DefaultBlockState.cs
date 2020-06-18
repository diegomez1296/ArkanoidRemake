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
        block.CurrentSprite.sprite = GameController.Instance.Data.blockSprites[UnityEngine.Random.Range(1, 5)];
        block.GetComponent<IgnoreColliderEffect>().enabled = true;
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        if (block.HP <= 0)
            block.gameObject.SetActive(false);
    }
}
