using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int lives = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.lives--;
        this.ModifyOpacity();

        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void ModifyOpacity()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = color.a - (color.a * 0.20f);
        GetComponent<SpriteRenderer>().color = color;
    }
}
