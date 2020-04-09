using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArkanoidUI : MonoBehaviour
{
    public Image live1, live2, live3;
    BallArkanoid ball;
    public Text gameOverText, gameWinText, highscoreText;
    private bool hasTheGameEnded = false;
    private float gameTime = 0.0f;
    public Text durationText;

    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("Ball").GetComponent<BallArkanoid>();
        this.gameOverText.enabled = false;
        this.gameWinText.enabled = false;
        this.highscoreText.text = "MEJOR: " + PlayerPrefs.GetFloat("highscore", 9999).ToString("N2");
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
        if (hasTheGameEnded) return;
        this.gameTime += Time.deltaTime;
        this.durationText.text = "Tiempo: " + this.gameTime.ToString("f2");

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
            Invoke("GoToMainMenu", 2.0f);
            hasTheGameEnded = true;
        }

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        if (blocks.Length == 0)
        {
            this.gameWinText.enabled = true;
            gameWinText.text = "ENHORABUENA\nHAS GANADO EN\n" + gameTime.ToString("N2");
            Invoke("GoToMainMenu", 4.0f);
            hasTheGameEnded = true;

            float highscore = PlayerPrefs.GetFloat("highscore", 9999);
            if (gameTime < highscore)
            {
                PlayerPrefs.SetFloat("highscore", gameTime);
            }
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
