using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : ArkanoidObject
{
    public event Action OnCollected;

    private void Start()
    {
        //SetState(new DefaultBallState(this));
    }

    private void Update()
    {

    }

    public void Collect(Collision2D collision)
    {
        OnCollected?.Invoke();
    }
}
