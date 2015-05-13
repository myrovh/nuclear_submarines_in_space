using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
public class Planet : MonoBehaviour
{
    public float OrbitKick;
    public Transform OrbitTarget;
    private Rigidbody _planetPhysics;

    private void Start()
    {
        _planetPhysics = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(OrbitTarget);
        while (OrbitKick > 0)
        {
            _planetPhysics.AddForce(transform.right*OrbitKick);
            OrbitKick = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_planetPhysics != null)
        {
            Gizmos.color = Color.red;
            var direction = _planetPhysics.velocity;
            Gizmos.DrawRay(transform.position, direction);
        }
    }
}