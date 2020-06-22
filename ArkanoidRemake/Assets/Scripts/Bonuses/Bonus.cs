using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : ArkanoidObject
{
    public int bonusScore = 100;
    public delegate void OnCollectBonus(Plank plank);
    public event OnCollectBonus OnCollected;

    public void CollectBonus(Plank plank)
    {
        if (IsUsed) return;

        //GameController.Instance.Audio.PlayCollectSFX();
        OnCollected(plank);
        this.gameObject.SetActive(false);
        IsUsed = true;
        Destroy(this.gameObject);
    }
}
