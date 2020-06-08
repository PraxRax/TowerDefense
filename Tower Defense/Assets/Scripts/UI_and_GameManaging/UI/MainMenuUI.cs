using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public SceneFader sceneFade;

    public string sceneToLoad;

    public AnimationCurve timeScaleCurve;

    void Start()
    {
        Time.timeScale = timeScaleCurve.Evaluate(0f);
    }

    public void Play()
    {
        StartCoroutine(PlayCo());

        sceneFade.FadeTo(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator PlayCo()
    {
        float temp = 0f;

        while(temp < 1f)
        {
            temp += Time.deltaTime;

            Time.timeScale = timeScaleCurve.Evaluate(temp);

            yield return 0;
        }
    }
}
