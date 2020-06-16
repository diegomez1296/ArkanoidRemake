using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    protected BlockState currentblockState;

    public BlockAsset blockAsset;
    public float HP { get; set; }
    public float Score { get; set; }
    public float Bonus { get; set; }
    public SpriteRenderer CurrentSprite => GetComponent<SpriteRenderer>();

    public event Action OnHitted;

    public void SetState(BlockState blockState) => currentblockState = blockState;

    public void SetPosition(Vector2 newPosition) => this.transform.position = newPosition;

    public void GetHit()
    {
        OnHitted?.Invoke();
    }

    
}
