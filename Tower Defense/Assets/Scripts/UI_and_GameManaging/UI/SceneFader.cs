using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    [Header("Curves")]

    public AnimationCurve curveFadeIn;

    public AnimationCurve curveFadeOut;

    public bool doFadeOut;

    private Color startColor;

    void Start()
    {
        startColor = img.color;

        if (doFadeOut)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            startColor.a = 0f;
            img.color = startColor;
        }
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeIn(scene));
    }

    private IEnumerator FadeOut()
    {
        float t = curveFadeOut[curveFadeOut.length - 1].time;

        while(t > 0f)
        {
            t -= Time.deltaTime;

            startColor.a = curveFadeOut.Evaluate(t);

            img.color = startColor;
            yield return 0;
        }
    }

    private IEnumerator FadeIn(string scene)
    {
        float t = 0f;

        float length = curveFadeIn[curveFadeIn.length - 1].time;

        while (t < length)
        {
            t += Time.deltaTime;

            startColor.a = curveFadeIn.Evaluate(t);

            img.color = startColor;
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
