﻿using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
// ReSharper disable once CheckNamespace
public class Planet : MonoBehaviour
{
    // ReSharper disable once MemberCanBePrivate.Global
    public float OrbitKick;
    public float SpinSpeed;
    [UsedImplicitly] public Transform OrbitTarget;
    private Rigidbody _planetPhysics;

    private void Start()
    {
        _planetPhysics = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (OrbitTarget != null)
        {
            transform.LookAt(OrbitTarget);
        }
        while (OrbitKick > 0)
        {
            _planetPhysics.AddForce(transform.right*OrbitKick);
            OrbitKick = 0;
        }
        while (SpinSpeed > 0)
        {
            _planetPhysics.AddTorque(transform.forward*SpinSpeed);
            SpinSpeed = 0;
        }
    }

}