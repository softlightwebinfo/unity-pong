using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public bool gameStarted;
    public Canvas startGameCanvas;

    private void Awake()
    {
        if (!sharedInstance) sharedInstance = this;
        startGameCanvas.enabled = true;
    }

    public void StartGame()
    {
        this.gameStarted = true;
        startGameCanvas.enabled = false;
    }
}
