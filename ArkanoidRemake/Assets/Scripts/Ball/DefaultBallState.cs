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
        ball.CurrentSpeed = 0.75f;
        ball.SpeedIncrease = 0.001f;
        ball.OnHitted -= OnHit;
        ball.OnHitted += OnHit;
    }

    protected override void OnHit()
    {
        //if (ball.CurrentSpeed < 1.05f)
        //{
        //    ball.CurrentSpeed += ball.SpeedIncrease;
        //    ball.BallRB.velocity *= ball.CurrentSpeed;
        //}
    }
}
