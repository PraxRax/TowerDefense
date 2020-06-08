using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWon : MonoBehaviour
{
    public string mainMenuScene;

    public SceneFader sceneFader;

    [Header("Next Level Properties")]
    public string nextLevel;
    public int levelToUnlock;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenuScene);
    }
}
