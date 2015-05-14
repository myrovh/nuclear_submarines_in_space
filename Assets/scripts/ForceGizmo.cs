using UnityEngine;
using System.Collections;

public class ForceGizmo : MonoBehaviour {
    private Rigidbody _physics;

    void Start()
    {
        _physics = gameObject.GetComponent<Rigidbody>();
    }

    private void OnDrawGizmosSelected()
    {
        if (_physics == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        var direction = _physics.velocity;
        Gizmos.DrawRay(transform.position, direction);
    }
}