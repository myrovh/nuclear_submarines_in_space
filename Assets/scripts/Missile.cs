using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float ForwardThrust = 300.0f;
    public float Throttle = 1.0f;
    public float SecondsOfFuel = 15.0f;
    public Transform Target;
    public GameObject Explosion;
    private TrailRenderer _trail;
    private Rigidbody _rigidbody;
    private Vector3 _updateTickForce;
    private Vector3 _updateTickRotation;

	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	    _trail = GetComponent<TrailRenderer>();
	    _updateTickForce = Vector3.zero;
	    _updateTickRotation = Vector3.zero;
	}

    void Update()
    {
        transform.LookAt(Target);
    }

    void FixedUpdate()
    {
        if (SecondsOfFuel > 0)
        {
            AddForceForward(Throttle);
            LoseFuel();

            _rigidbody.AddRelativeForce(_updateTickForce);
            _rigidbody.AddTorque(_updateTickRotation);
            _updateTickForce = Vector3.zero;
            _updateTickRotation = Vector3.zero;
        }
        else
        {
            _trail.enabled = false;
        }
    }

    void OnCollisionEnter()
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void AddForceForward(float throttle)
    {
        float angle = Vector3.Angle(Target.position - transform.position, _rigidbody.velocity);
        _updateTickForce += Vector3.forward*(ForwardThrust*angle*throttle*Time.deltaTime);
    }

    private void LoseFuel()
    {
        SecondsOfFuel = SecondsOfFuel - Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var direction = Target.position - transform.position;
        Gizmos.DrawRay(transform.position, direction);

        Gizmos.color = Color.blue;
        var rotation = transform.forward * 10;
        Gizmos.DrawRay(transform.position, rotation);

    }
}