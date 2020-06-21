using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerSizeBonusState : ChangeSizeBonusState
{
    
    public SmallerSizeBonusState(Bonus bonus) : base(bonus)
    {
    }

    protected override void Initialize()
    {
        bonus.GetComponent<SpriteRenderer>().sprite = GameController.Instance.Data.bonusSprites[7];
        IsBiggerSize = false;
        base.Initialize();
    }
}
