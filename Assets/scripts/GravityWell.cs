using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityWell : MonoBehaviour
{
    public float GravityRange = 50f;

    private List<Rigidbody> _objectsInRange = new List<Rigidbody>();
    private float GravityStrength = GlobalGravity.GravityStrength;
    private float GravityStrengthExponent = GlobalGravity.GravityStrengthExponent;
    private string TargetTag = GlobalGravity.TargetTag;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
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
            a.AddForce(GravityCalculation(a.position));
        }
    }

    public Vector3 GravityCalculation(Vector3 inputPosition)
    {
        float forceMuliplier = (-GravityStrength/
                                Mathf.Pow(Mathf.Max(Vector3.Distance(transform.position, inputPosition), 1f),
                                    GravityStrengthExponent));
        forceMuliplier *= _rigidbody.mass;
        Vector3 forceDirection = (inputPosition - transform.position).normalized;
        forceDirection = forceDirection*forceMuliplier;

        return forceDirection;
    }
}