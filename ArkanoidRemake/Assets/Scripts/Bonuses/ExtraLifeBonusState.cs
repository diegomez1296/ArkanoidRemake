using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeBonusState : BonusState
{
    public ExtraLifeBonusState(Bonus bonus) : base(bonus)
    {
    }

    protected override void Initialize()
    {
        bonus.GetComponent<SpriteRenderer>().sprite = GameController.Instance.Data.bonusSprites[2];
        bonus.OnCollected -= OnCollect;
        bonus.OnCollected += OnCollect;
    }

    protected override void OnCollect(Plank plank)
    {
        plank.HP++;
        GameData.CurrentScore += bonus.bonusScore;
    }
}
