using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerSizeBonusState : ChangeSizeBonusState
{
    public BiggerSizeBonusState(Bonus bonus) : base(bonus)
    {
    }

    protected override void Initialize()
    {
        bonus.GetComponent<SpriteRenderer>().sprite = GameController.Instance.Data.bonusSprites[1];
        IsBiggerSize = true;
        base.Initialize();
    }
}
