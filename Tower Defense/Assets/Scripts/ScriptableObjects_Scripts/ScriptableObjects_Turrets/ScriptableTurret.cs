using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_ScriptableTurret", menuName = "ScriptableObjects/ScriptableTurret")]
public class ScriptableTurret : ScriptableObject
{
    public ScriptableTurretHead ST;

    [Header("UpgradedTurretScriptableObject")]
    public ScriptableTurret upgradedTurretScriptableObject;

    [Header("PrefabReference")]
    public GameObject prefab;

    [Header("GeneralStats")]
    public float range;

    public float turnSpeed;

    public float cost;

    public float upgradeCost;

    public float GetSellAmount()
    {
        return sellAmount;
    }

    public float sellAmount;

    [Header("UpgradedTurret")]
    public GameObject upgradedPrefab;

    [Header("NormalTurretStats")]
    public float damage;
    public float fireRate;

    [Header("LaserTurretStats")]
    public int damageOverTime;
    public float slowAmount;

    [Header("Projectile Properties")]
    public GameObject bulletPrefab;
    public float speed;
    public float explosionRadius;

    [Header("Optional_NormalTurret")]
    public GameObject bulletFiredEffect;

    public string enemyTag()
    {
        return ST.TagForEnemy;
    }
}
