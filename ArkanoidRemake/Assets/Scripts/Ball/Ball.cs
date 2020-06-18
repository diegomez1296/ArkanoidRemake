using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : ArkanoidObject
{
    private bool isRunning = false;
    private Plank Plank => FindObjectOfType<Plank>();

    public Rigidbody2D BallRB => GetComponent<Rigidbody2D>();
    public float Damage { get; set; }

    public float CurrentSpeed { get; set; }
    public float SpeedIncrease { get; set; }

    public event Action OnHitted;

    private void Start()
    {
        SetState(new DefaultBallState(this));
    }

    private void Update()
    {
        if (!isRunning)
        {
            this.transform.position = new Vector3(Plank.transform.position.x, this.transform.position.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                BallRB.isKinematic = false;
                BallRB.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 0.5f) * GameController.START_BALL_SPEED * CurrentSpeed);
                isRunning = true;
            }
        }
    }

    public void GetHit(Collision2D collision)
    {
        OnHitted?.Invoke();
    }
}
