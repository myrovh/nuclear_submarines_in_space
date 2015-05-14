﻿using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    private readonly List<Rigidbody> _objectsInRange = new List<Rigidbody>();
    public float GravityRange = 50f;
    public float GravityStrength = 50f;
    public float GravityStrengthExponent = 1.1f;
    public string TargetTag = "";

    private void Start()
    {
        // Setup collider used to add rigidbodies to gravity influence
        var thisCollider = gameObject.AddComponent<SphereCollider>();
        thisCollider.radius = GravityRange;
        thisCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == TargetTag)
        {
            _objectsInRange.Add(otherCollider.GetComponent<Rigidbody>());
            // Add check to debug log if no rigidbody exists
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.tag == TargetTag)
        {
            _objectsInRange.Remove(otherCollider.GetComponent<Rigidbody>());
            // Add check to debug log if no rigidbody exists
        }
    }

    private void FixedUpdate()
    {
        foreach (var a in _objectsInRange)
        {
            a.AddForce(GravityCalculation(a));
        }
    }

    public Vector3 GravityCalculation(Rigidbody inputObject)
    {
        float forceMuliplier = (-GravityStrength/
                                Mathf.Pow(Mathf.Max(Vector3.Distance(transform.position, inputObject.position), 1f),
                                    GravityStrengthExponent));
        Vector3 forceDirection = (inputObject.position - transform.position).normalized;
        forceDirection = forceDirection*forceMuliplier;

        return forceDirection;
    }
}