using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    protected BallState currentBallState;

    public float Damage { get; set; }
    public float CurrentSpeed { get; set; }
    public float SpeedIncrease { get; set; }

    public event Action OnHitted;

    public void SetState(BallState ballState) => currentBallState = ballState;

    public void SetPosition(Vector2 newPosition) => this.transform.position = newPosition;

    public void GetHit()
    {
        OnHitted?.Invoke();
    }
}
