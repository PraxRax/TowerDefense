using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    [Header("References")]
    public GameObject gameOverUI;

    public GameObject levelWonUI;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if(PlayerStats.Lives <= 0f)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;

        levelWonUI.SetActive(true);
    }
}
