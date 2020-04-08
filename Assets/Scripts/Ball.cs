using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 25.0f;
    private bool hasTheBallMoved = false;

    private void Update()
    {
        if (GameManager.sharedInstance.gameStarted && !this.hasTheBallMoved)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * this.speed;
            this.hasTheBallMoved = true;
        }

        if (GameManager.sharedInstance.gameStarted)
        {
            string racketName = GetComponent<Rigidbody2D>().velocity.x > 0 ? "RacketLeft" : "RacketRight";
            GameObject paddle = GameObject.Find(racketName);
            GetComponent<SpriteRenderer>().color = paddle.GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft")
        {
            float y = this.HitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * this.speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            float y = this.HitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * this.speed;
        }
    }

    float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
