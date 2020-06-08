using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateStats : MonoBehaviour
{
    public ScriptableTurret[] turretStats;

    public ScriptableEnemy[] enemyStats;

    private GameObject[] statReferences;

    void Start()
    {
        statReferences = new GameObject[transform.childCount];

        for (int i = 0; i < statReferences.Length; i++)
        {
            statReferences[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Calculate()
    {
        float tempDPS = 404;
        float tempCost = 404;

        for (int i = 0; i < turretStats.Length; i++)
        {
            if(turretStats[i].damage != 0)
            {
                tempDPS = turretStats[i].damage / turretStats[i].fireRate;
                DisplayDPS(i, tempDPS);
            }
            else if(turretStats[i].damageOverTime != 0)
            {
                tempDPS = turretStats[i].damageOverTime;
                DisplayDPS(i, tempDPS);
            }

            tempCost = turretStats[i].cost;

            DisplayCost(i, tempCost);
        }
    }

    private void DisplayDPS(int i, float temp)
    {
        statReferences[0].transform.GetChild(i).gameObject.GetComponent<Text>().text = temp + "DPS";
    }

    private void DisplayCost(int i, float temp)
    {
        statReferences[0].transform.GetChild(i).gameObject.GetComponent<Text>().text = "$" + temp;
    }
}
