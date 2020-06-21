using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChangeSizeBonusState : BonusState
{
    protected bool IsBiggerSize { get; set; }
    public ChangeSizeBonusState(Bonus bonus) : base(bonus)
    {
    }

    protected override void Initialize()
    {
        bonus.OnCollected -= OnCollect;
        bonus.OnCollected += OnCollect;
    }

    protected override void OnCollect(Plank plank)
    {
        plank.GetSizeBonus(IsBiggerSize);
        GameData.CurrentScore += bonus.bonusScore;
    }
}
