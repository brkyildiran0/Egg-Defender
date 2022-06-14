using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMovementHandler>().transform;
    }

    void Update()
    {
        AimBow();
    }

    void AimBow()
    {
        weapon.transform.LookAt(target);
    }
}
