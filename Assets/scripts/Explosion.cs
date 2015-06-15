using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    private List<Rigidbody> _objectsInRange = new List<Rigidbody>();
    private SphereCollider _explosionRadius;
    public float ExplosionRange = 1.0f;
    public float ExplosionForce = 5.0f;
    public float ExplosionRate = 3.0f;
    public float Lifetime = 1.0f;


    // Use this for initialization
    void Start()
    {
        _explosionRadius = gameObject.AddComponent<SphereCollider>();
        _explosionRadius.radius = ExplosionRange;
        _explosionRadius.isTrigger = true;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        Rigidbody tempCollider = otherCollider.GetComponent<Rigidbody>();
        if (tempCollider != null)
        {
            _objectsInRange.Add(tempCollider);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        Rigidbody tempCollider = otherCollider.GetComponent<Rigidbody>();
        if (tempCollider != null)
        {
            _objectsInRange.Remove(tempCollider);
        }
    }

    private void Update()
    {
        Lifetime -= Time.deltaTime;

        if (Lifetime >= 0)
        {
            ExplosionStart();
            transform.localScale = transform.localScale * 1.1f;
            _explosionRadius.radius = _explosionRadius.radius + 0.1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ExplosionStart()
    {
        foreach (var a in _objectsInRange)
        {
            if (a != null)
            {
                if (a.isKinematic)
                {
                    a.AddExplosionForce(ExplosionForce, gameObject.transform.position, ExplosionRange);
                }
            }
        }
    }
}