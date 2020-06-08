using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    public override void Update()
    {
        if (target == null)
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }

            return;
        }

        LookOnTarget();

        Laser();
    }

    private void Laser()
    {
        targetEnemyScript.TakeDamage(scriptableObject.damageOverTime * Time.deltaTime);
        targetEnemyScript.Slow(scriptableObject.slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
}
