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
        block.HP = 999; 
        block.Score = 1000;
        block.BonusPercent = 100;
        block.CurrentSprite.sprite = GameController.Instance.Data.blockSprites[0];
        //block.AudioSource.clip = GameController.Instance.Data.audioClips[1];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        GameController.Instance.Audio.PlayDefBlockSFX();
        block.DestroyBlock();
    }
}
