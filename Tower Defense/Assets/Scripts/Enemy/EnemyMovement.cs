using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    // neccassary components
    private Transform target;
    private int wavePointIndex = 0;

    private Enemy enemyScript;

    void Start()
    {
        enemyScript = GetComponent<Enemy>();

        target = WayPoints.Points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemyScript.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemyScript.speed = enemyScript.scriptableEnemy.startSpeed;
    }

    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.Points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = WayPoints.Points[wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
