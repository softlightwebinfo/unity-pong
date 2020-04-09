using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public bool gameStarted;
    public Canvas startGameCanvas;
    GameObject ball;
    Vector2 nextDirection;

    private void Awake()
    {
        if (!sharedInstance) sharedInstance = this;
        startGameCanvas.enabled = true;
    }

    public void StartGame()
    {
        this.gameStarted = true;
        startGameCanvas.enabled = false;
        this.ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void GoalScored()
    {
        this.ball.GetComponent<TrailRenderer>().time = 0;
        this.ball.transform.localPosition = Vector3.zero;
        this.nextDirection = new Vector2(-this.ball.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Invoke("LaunchBall", 2.0f);
    }

    void LaunchBall()
    {
        Ball b = this.ball.GetComponent<Ball>();
        this.ball.GetComponent<TrailRenderer>().time = 1;
        this.ball.GetComponent<Rigidbody2D>().velocity = this.nextDirection.normalized * b.speed;
    }
}