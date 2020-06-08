using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_ScriptableEnemy", menuName = "ScriptableObjects/ScriptableEnemy")]
public class ScriptableEnemy : ScriptableObject
{
    [Header("Stats")]
    public float startSpeed;

    public float startHealth;

    public int moneyGain;
}
