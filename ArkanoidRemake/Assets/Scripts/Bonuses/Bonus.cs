using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : ArkanoidObject
{

    public bool isUsed = false;
    public int bonusScore = 100;
    public delegate void OnCollectBonus(Plank plank);
    public event OnCollectBonus OnCollected;

    public void CollectBonus(Plank plank)
    {
        if (isUsed) return;

        OnCollected(plank);
        this.gameObject.SetActive(false);
        isUsed = true;
        Destroy(this.gameObject);
    }
}
