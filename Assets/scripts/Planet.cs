using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour
{
    public Transform orbit_target;
    public float orbit_kick;

    private Rigidbody planet_physics;

    private void Start()
    {
        planet_physics = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(orbit_target);
        while (orbit_kick > 0)
        {
            planet_physics.AddForce(transform.right*orbit_kick);
            orbit_kick = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (planet_physics != null)
        {
            Gizmos.color = Color.red;
            Vector3 direction = planet_physics.velocity;
            Gizmos.DrawRay(transform.position, direction);
        }
    }
}