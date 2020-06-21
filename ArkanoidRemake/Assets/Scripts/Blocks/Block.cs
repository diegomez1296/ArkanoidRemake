using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : ArkanoidObject
{
    public float maxHP;
    public float HP { get; set; }
    public int Score { get; set; }
    public float BonusPercent { get; set; }
    public SpriteRenderer CurrentSprite => GetComponent<SpriteRenderer>();

    public event Action OnHitted;

    public void GetHit(float damage)
    {
        HP -= damage;
        OnHitted?.Invoke();
    }

    public void DestroyBlock()
    {
        if (HP <= 0 && !isUsed)
        {
            Debug.Log("DestroyBlock");
            if (!typeof(SolidBlockState).IsInstanceOfType(this))
            {
                LevelController.Instance.Map.BlocksDestroyed++;
                LevelController.Instance.Map.CheckDestroyedBlocks();
            }

            if (100 - BonusPercent <= UnityEngine.Random.Range(0, 100))
                GameController.Instance.CreateBonus(this);

            gameObject.SetActive(false);
            GameData.CurrentScore += Score;
            isUsed = true;
        }
    }
}
