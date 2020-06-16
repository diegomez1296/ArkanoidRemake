using UnityEngine;
using System.Collections;

public abstract class BlockState
{
    protected Block block;

    public BlockState(Block block)
    {
        this.block = block;
        Initialize();
    }

    protected virtual void Initialize() //This method describe values of our Block
    {
        if (block.blockAsset == null) return;

        block.HP = block.blockAsset._hp;
        block.Score = block.blockAsset._score;
        block.Bonus = block.blockAsset._bonus;
        block.CurrentSprite.sprite = block.blockAsset.Sprites[0];
        block.OnHitted -= OnHit;
        block.OnHitted += OnHit;
    }

    protected abstract void OnHit(); //This method describe what will happen after hit
}
