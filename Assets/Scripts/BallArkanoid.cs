using System.Collections;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    public float speed = 10.0f;
    private float speedInitial;
    public GameObject ballStartPosition;
    public int lives = 3;

    [SerializeField]
    [Range(1.0f, 2.0f)]
    public float difficultyFactor = 1.005f;

    void Start()
    {
        this.speedInitial = this.speed;
        this.StartMovement();
        StartCoroutine("UpgradeDifficulty");
    }

    IEnumerator UpgradeDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            this.speed *= this.difficultyFactor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
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
        this.lives--;
        this.speed = this.speedInitial;
        this.gameObject.transform.position = this.ballStartPosition.transform.position;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (lives > 0)
        {
            Invoke("RestatartBallMovement", 2.0f);
        }
    }

    public void StartMovement()
    {
        GetComponent<Rigidbody2D>().velocity = (Vector2.up * this.speed);
    }

    public void RestatartBallMovement()
    {
        this.StartMovement();
    }
}
