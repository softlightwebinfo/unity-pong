using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalZone : MonoBehaviour
{
    public Text scoreText;
    int score;

    private void Awake()
    {
        this.score = 0;
    }

    private void Update()
    {
        this.scoreText.text = this.score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Ball"))
        {
            this.score += 1;
        }
    }
}
