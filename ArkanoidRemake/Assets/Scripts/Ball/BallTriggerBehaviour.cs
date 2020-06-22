using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriggerBehaviour : MonoBehaviour
{
    private Ball Ball => GetComponent<Ball>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.GetComponent<IgnoreColliderEffect>())
            Ball.GetHit(collision);

        CollisionWithBlock(collision);
    }

    private void CollisionWithBlock(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Block>())
        {
            collision.gameObject.GetComponent<Block>().GetHit(Ball.Damage);
        }
    }
}
