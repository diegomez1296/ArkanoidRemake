using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerBallBonusState : BonusState
{
    public SlowerBallBonusState(Bonus bonus) : base(bonus)
    {
    }

    protected override void Initialize()
    {
        bonus.GetComponent<SpriteRenderer>().sprite = GameController.Instance.Data.bonusSprites[7];
        bonus.OnCollected -= OnCollect;
        bonus.OnCollected += OnCollect;
    }

    protected override void OnCollect(Plank plank)
    {
        plank.ball.CurrentSpeed = 1;
        float tmpX = plank.ball.BallRB.velocity.x - (int)plank.ball.BallRB.velocity.x;
        float tmpY = plank.ball.BallRB.velocity.y - (int)plank.ball.BallRB.velocity.y;
        plank.ball.BallRB.velocity = Vector2.zero;
        plank.ball.BallRB.AddForce(new Vector2(tmpX, tmpY) * GameController.START_BALL_SPEED * plank.ball.CurrentSpeed);
        Debug.LogError("To fix");
        GameData.CurrentScore += bonus.bonusScore;
    }
}
