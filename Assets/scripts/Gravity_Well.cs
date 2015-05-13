using UnityEngine;
using System.Collections.Generic;

public class gravity_well : MonoBehaviour
{
    public float gravity_strength = 50f;
    public float gravity_strength_exponent = 1.1f;
    public float gravity_range = 50f;
    public string target_tag = "";

    private List<Rigidbody> objects_in_range = new List<Rigidbody>();

    private void Start()
    {
        // Setup collider used to add rigidbodies to gravity influence
        SphereCollider this_collider = gameObject.AddComponent<SphereCollider>();
        this_collider.radius = gravity_range;
        this_collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other_collider)
    {
        if (other_collider.tag == target_tag)
        {
            objects_in_range.Add(other_collider.GetComponent<Rigidbody>());
            // Add check to debug log if no rigidbody exists
        }
    }

    private void OnTriggerExit(Collider other_collider)
    {
        if (other_collider.tag == target_tag)
        {
            objects_in_range.Remove(other_collider.GetComponent<Rigidbody>());
            // Add check to debug log if no rigidbody exists
        }
    }

    private void FixedUpdate()
    {
        float force_muliplier;
        Vector3 force_direction;
        foreach (Rigidbody a in objects_in_range)
        {
            force_muliplier = (-gravity_strength/
                               Mathf.Pow(Mathf.Max(Vector3.Distance(transform.position, a.position), 1f),
                                   gravity_strength_exponent));
            force_direction = (a.position - transform.position).normalized;
            a.AddForce(force_direction*force_muliplier);
        }
    }
}