using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem arrowParticle;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimBow();
    }

    void AimBow()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.transform.LookAt(target);
        FireArrows(targetDistance);
    }
    
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        for (int i = 0; i < enemies.Length; i++)
        {
            float targetDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemies[i].transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void FireArrows(float dist)
    {
        var emissionModule = arrowParticle.emission;

        if (dist >= range)
        {
            emissionModule.enabled = false;
        }
        else
        {
            emissionModule.enabled = true;
        }
    }
}
