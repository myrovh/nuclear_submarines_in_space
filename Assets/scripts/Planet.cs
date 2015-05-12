using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public Transform orbit_target; 
    public int orbit_speed;

    private Rigidbody planet_physics;

    void Start()
    {
        planet_physics = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.LookAt(orbit_target);
        while (orbit_speed > 0)
        {
            planet_physics.AddForce(transform.right * orbit_speed);
            orbit_speed = 0;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (planet_physics != null)
        {
            Gizmos.color = Color.red;
            Vector3 direction = planet_physics.velocity;
            Gizmos.DrawRay(transform.position, direction);
        }
    }
}
