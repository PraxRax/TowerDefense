using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    private Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
    }

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
