using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovementDecoration : MonoBehaviour
{
    public GameObject CameraObject;

    // neccassary components
    private Transform target;
    private int wavePointIndex = 1;

    private Enemy enemyScript;

    private int waveIndexDirection = 1;

    private CameraMainMenu cameraScript;

    void Start()
    {
        enemyScript = GetComponent<Enemy>();

        cameraScript = CameraObject.GetComponent<CameraMainMenu>();

        target = WayPoints.Points[wavePointIndex];
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
        if (wavePointIndex >= WayPoints.Points.Length - 1 || wavePointIndex == 0)
        {
            waveIndexDirection = -waveIndexDirection;

            cameraScript.ChangeDirection();
        }

        wavePointIndex += waveIndexDirection;
        target = WayPoints.Points[wavePointIndex];
    }
}
