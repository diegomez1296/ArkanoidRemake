using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : ArkanoidObject
{
    public bool IsRunning { get; set; }
    private Plank Plank => FindObjectOfType<Plank>();

    public Rigidbody2D BallRB => GetComponent<Rigidbody2D>();
    public float Damage { get; set; }

    public float CurrentSpeed { get; set; }
    public float SpeedIncrease { get; set; }

    public event Action OnHitted;

    private Vector2 startPosition;

    private void Start()
    {
        CurrentState = new DefaultBallState(this);
        startPosition = this.transform.position;
    }

    private void Update()
    {
        if (!GameController.IsGameRunning) return;

        if (!IsRunning)
        {
            this.transform.position = new Vector3(Plank.transform.position.x, startPosition.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                BallRB.isKinematic = false;
                BallRB.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 0.5f) * GameController.START_BALL_SPEED * CurrentSpeed);
                IsRunning = true;
            }
        }
    }

    public void GetHit(Collision2D collision)
    {
        OnHitted?.Invoke();
    }
}
