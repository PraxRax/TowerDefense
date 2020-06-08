using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public ScriptableTurret scriptableObject;

    [Header("References")]

    public Transform PartToRotate;

    public Transform firePoint;

    // neccessary components
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public Enemy targetEnemyScript;

    private float fireCountDown;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(scriptableObject.enemyTag());
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= scriptableObject.range)
        {
            target = nearestEnemy.transform;
            targetEnemyScript = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    public virtual void Update()
    {
        if(target == null)
        {
            return;
        }

        LookOnTarget();

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / scriptableObject.fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    public void LookOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * scriptableObject.turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(scriptableObject.bulletPrefab, firePoint.position, firePoint.rotation);

        if(scriptableObject.bulletFiredEffect != null)
        {
            GameObject effect = (GameObject)Instantiate(scriptableObject.bulletFiredEffect, firePoint.position, firePoint.rotation);
            Destroy(effect, 2f);
        }

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scriptableObject.range);
    }
}
