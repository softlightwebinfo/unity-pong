using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject ballStartPosition;

    void Start()
    {
        this.StartMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            float x = this.HitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * this.speed;
        }
    }

    private float HitFactor(Vector2 ball, Vector2 paddle, float paddleWidth)
    {
        return (ball.x - paddle.x) / paddleWidth;
    }

    public void ResetBall()
    {
        this.gameObject.transform.position = this.ballStartPosition.transform.position;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Invoke("RestatartBallMovement", 2.0f);
    }

    public void StartMovement()
    {
        GetComponent<Rigidbody2D>().velocity = -(Vector2.up * this.speed);
    }

    public void RestatartBallMovement()
    {
        this.StartMovement();
    }
}
