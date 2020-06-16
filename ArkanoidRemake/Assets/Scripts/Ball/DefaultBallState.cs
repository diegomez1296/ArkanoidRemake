using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBallState : BallState
{
    public DefaultBallState(Ball ball) : base(ball)
    {
    }

    protected override void Initialize()
    {
        ball.Damage = 1;
        ball.CurrentSpeed = 1;
        ball.SpeedIncrease = 0.01f;
    }

    protected override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
