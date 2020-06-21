using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public Ball ball;
    private float hp;
    public float HP 
    {
        get { return hp; }
        set 
        {
            hp = value;
            if (hp > 5) hp = 5;
            UIController.Instance.Game.SetHP(hp);
        }
    }

    public void LoseLife()
    {
        HP--;
        ball.IsRunning = false;
        ball.BallRB.isKinematic = true;
        ball.BallRB.velocity = Vector2.zero;
        if (hp < 0) 
            GameController.Instance.LoseGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
            collision.GetComponent<Bonus>().CollectBonus(this);
    }
}
