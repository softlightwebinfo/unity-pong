using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArkanoidUI : MonoBehaviour
{
    public Image live1, live2, live3;
    BallArkanoid ball;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("Ball").GetComponent<BallArkanoid>();
        this.gameOverText.enabled = false;
    }

    void DeleteLive(ref Image imageLive)
    {
        Color c = imageLive.GetComponent<Image>().color = Color.red;
        c.a = 0.6f;
        imageLive.GetComponent<Image>().color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.ball.lives < 3)
        {
            this.DeleteLive(ref this.live3);
        }
        if (this.ball.lives < 2)
        {
            this.DeleteLive(ref this.live2);
        }
        if (this.ball.lives < 1)
        {
            this.DeleteLive(ref this.live1);
            this.gameOverText.enabled = true;
        }
    }
}
