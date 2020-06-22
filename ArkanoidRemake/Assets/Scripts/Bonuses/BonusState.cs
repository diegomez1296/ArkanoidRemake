using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusState : ArkanoidState 
{
    protected Bonus bonus;

    protected BonusState(Bonus bonus)
    {
        this.bonus = bonus;
        bonus.IsUsed = false;
        Initialize();
    }

    protected abstract void OnCollect(Plank plank); //This method describe what will happen after collect the bonus
}
