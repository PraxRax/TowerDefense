using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainMenu : MonoBehaviour
{
    public Transform targetToLookAt;

    [Header("Startposition")]
    public float maxPosition_X;
    public float minPosition_X;

    public Vector3 offsetToEnemy;

    [Header("Movement")]
    public float moveSpeed;

    public Vector3 moveDirection;

    [Header("Distance to Enemy")]
    public float maxDistance;
    public float minDistance;

    public float distanceMoveSpeed;

    [Header("Boundary for Altitude")]
    public float maxAltitude;
    public float minAltitude;

    public float moveCooldownAltitude;

    public float factorOfAltitudeMoveCorrection;

    // neccassary components
    private bool ableToMoveOnAltitude;
    private float cooldownAltitude;
    private float moveOnAltitude;

    void Start()
    {
        moveOnAltitude = moveDirection.y;
        cooldownAltitude = moveCooldownAltitude;

        Vector3 randomStartPosition = new Vector3(Random.Range(minPosition_X, maxPosition_X), transform.position.y, transform.position.z);

        transform.position = randomStartPosition;

        transform.Translate(offsetToEnemy);
    }

    void Update()
    {
        CheckAltitude();

        CheckDistance();

        Move();
    }

    private void Move()
    {
        transform.Translate(-offsetToEnemy);

        transform.LookAt(targetToLookAt);

        ApplyOffset();

        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
    }

    private void CheckAltitude()
    {
        if (ableToMoveOnAltitude && transform.position.y < minAltitude || transform.position.y > maxAltitude && ableToMoveOnAltitude)
        {
            moveDirection.y = 0f;
            moveOnAltitude = -moveOnAltitude;
            ableToMoveOnAltitude = false;
        }

        if (!ableToMoveOnAltitude)
        {
            cooldownAltitude -= Time.deltaTime;

            if (cooldownAltitude <= 0)
            {
                ableToMoveOnAltitude = true;
                moveDirection.y = moveOnAltitude;
                cooldownAltitude = moveCooldownAltitude;

                Move();
            }
        }
    }

    private void CheckDistance()
    {
        if(Vector3.Distance(targetToLookAt.position, transform.position) < minDistance)
        {
            transform.Translate(0f, 0f, -distanceMoveSpeed * Time.deltaTime);
        }
        else if(Vector3.Distance(targetToLookAt.position, transform.position) > maxDistance)
        {
            transform.Translate(0f, 0f, distanceMoveSpeed * Time.deltaTime);
        }
    }

    private void ApplyOffset()
    {
        transform.Translate(offsetToEnemy);
    }

    public void ChangeDirection()
    {
        moveDirection.x = -moveDirection.x;
    }
}
