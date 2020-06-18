using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : ArkanoidObject
{
    public float HP { get; set; }
    public float Score { get; set; }
    public float Bonus { get; set; }
    public SpriteRenderer CurrentSprite => GetComponent<SpriteRenderer>();

    public event Action OnHitted;

    private void Start()
    {
        SetState(new DefaultBlockState(this));
    }

    public void GetHit(float damage)
    {
        HP -= damage;
        OnHitted?.Invoke();
    }
}
