using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlankSize
{
    SMALL,
    MEDIUM,
    LARGE,
    XLARGE
}

public class Plank : MonoBehaviour
{
    public Ball ball;
    private PlankSize plankSize = PlankSize.MEDIUM;
    private CapsuleCollider2D capsuleCollider2D;
    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;
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

    private void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = spriteRenderer.size;
    }

    public void LoseLife()
    {
        HP--;
        ball.IsRunning = false;
        ball.BallRB.isKinematic = true;
        ball.BallRB.velocity = Vector2.zero;
        plankSize = PlankSize.MEDIUM;
        ChangeSize();
        if (hp < 0)
            GameController.Instance.LoseGame();
    }

    internal void GetSizeBonus(bool isBiggerSize)
    {
        if (isBiggerSize)
        {
            if (plankSize == PlankSize.XLARGE) return;
            plankSize++;
        }
        else
        {
            if (plankSize == PlankSize.SMALL) return;
            plankSize--; 
        }
        ChangeSize();
    }

    private void ChangeSize()
    {
        switch (plankSize)
        {
            case PlankSize.SMALL:
                capsuleCollider2D.size = new Vector2(startSize.x / 2, startSize.y);
                spriteRenderer.size = new Vector2(startSize.x / 2, startSize.y);
                break;
            case PlankSize.MEDIUM:
                capsuleCollider2D.size = new Vector2(startSize.x, startSize.y);
                spriteRenderer.size = new Vector2(startSize.x, startSize.y);
                break;
            case PlankSize.LARGE:
                capsuleCollider2D.size = new Vector2(startSize.x * 2, startSize.y);
                spriteRenderer.size = new Vector2(startSize.x * 2, startSize.y);
                break;
            case PlankSize.XLARGE:
                capsuleCollider2D.size = new Vector2(startSize.x * 3, startSize.y);
                spriteRenderer.size = new Vector2(startSize.x * 3, startSize.y);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
            collision.GetComponent<Bonus>().CollectBonus(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>())
        {
            Vector3 hitpoint = collision.contacts[0].point;
            Vector3 plankCenter = new Vector3(this.gameObject.transform.position.x, gameObject.transform.position.y);
            ball.BallRB.velocity = Vector3.zero;

            float difference = plankCenter.x - hitpoint.x;
            Debug.Log("difference: " + difference);
            if (hitpoint.x < plankCenter.x)
                ball.BallRB.AddForce(new Vector2(-(Mathf.Abs(difference * GameController.START_BALL_SPEED)), GameController.START_BALL_SPEED * ball.CurrentSpeed));
            else
                ball.BallRB.AddForce(new Vector2((Mathf.Abs(difference * GameController.START_BALL_SPEED)), GameController.START_BALL_SPEED * ball.CurrentSpeed));
        }
    }
}
