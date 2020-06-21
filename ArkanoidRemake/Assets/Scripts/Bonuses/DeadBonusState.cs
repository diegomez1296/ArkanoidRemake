using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBonusState : BonusState
{
    public DeadBonusState(Bonus bonus) : base(bonus)
    {
    }

    protected override void Initialize()
    {
        bonus.GetComponent<SpriteRenderer>().sprite = GameController.Instance.Data.bonusSprites[4];
        bonus.OnCollected -= OnCollect;
        bonus.OnCollected += OnCollect;
    }

    protected override void OnCollect(Plank plank)
    {
        plank.LoseLife();
        GameData.CurrentScore += bonus.bonusScore;
    }
}
