using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMoneyUI : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    public void MoneyEarned(float difference)
    {
        GetComponent<Text>().text = "+" + difference;
    }

    public void MoneyLost(float difference)
    {
        GetComponent<Text>().text = "-" + difference;
    }
}
