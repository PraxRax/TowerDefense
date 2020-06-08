using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public GameObject moneyWinText;
    public GameObject moneyLoseText;

    public Transform playerTransactionFeedbackPosition;

    // neccassary components
    private Text moneyText;

    private float previousMoney;

    private float currentMoney;

    void Start()
    {
        moneyText = GetComponent<Text>();
    }

    void Update()
    {
        currentMoney = PlayerStats.Money;

        if (currentMoney < previousMoney)
        {
            GameObject tempText = (GameObject)Instantiate(moneyLoseText, playerTransactionFeedbackPosition.position, Quaternion.Euler(90f, 0f, 0f));
            tempText.transform.SetParent(transform);
            float moneyLost = previousMoney - currentMoney;
            if (tempText != null)
            {
                tempText.GetComponent<ChangeMoneyUI>().MoneyLost(moneyLost);
            }
        }
        else if(currentMoney > previousMoney)
        {
            GameObject tempText = (GameObject)Instantiate(moneyWinText, playerTransactionFeedbackPosition.position, Quaternion.Euler(90f, 0f, 0f));
            tempText.transform.SetParent(transform);
            float moneyWon = currentMoney - previousMoney;
            if(tempText != null)
            {
                tempText.GetComponent<ChangeMoneyUI>().MoneyEarned(moneyWon);
            }
        }

        moneyText.text = "$" + currentMoney.ToString();

        previousMoney = currentMoney;
    }
}
