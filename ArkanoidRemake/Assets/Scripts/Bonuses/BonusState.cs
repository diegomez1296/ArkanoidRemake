using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusState : ArkanoidState 
{
    protected Bonus bonus;

    protected BonusState(Bonus bonus)
    {
        this.bonus = bonus;
        Initialize();
    }

    protected abstract void OnCollect(); //This method describe what will happen after collect the bonus
}
