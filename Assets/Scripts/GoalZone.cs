using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalZone : MonoBehaviour
{
    public Text scoreText;
    int score;
    public GameObject racket;

    private void Awake()
    {
        this.score = 0;
        this.scoreText.text = this.score.ToString();
        this.scoreText.color = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Ball"))
        {
            this.score += 1;
            this.scoreText.text = this.score.ToString();
        }
    }
}
