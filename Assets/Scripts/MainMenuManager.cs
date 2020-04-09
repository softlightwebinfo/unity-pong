using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public void LoadPong()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadArkanoid()
    {
        SceneManager.LoadScene("ArkanoidScene");
    }
}
