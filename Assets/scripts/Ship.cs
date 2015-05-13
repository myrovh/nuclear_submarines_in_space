using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

[UsedImplicitly]
public class Ship : MonoBehaviour
{
    public float ForwardThrust = 10.0f;
    public float OtherThrust = 5.0f;
    private Rigidbody _rigidbody;

	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	}

    public void AddForceForward(float throttle)
    {
        _rigidbody.AddForce(Vector3.forward * (ForwardThrust * throttle));
    }

    public void AddForceRight(float throttle)
    {
        _rigidbody.AddForce(Vector3.right * (OtherThrust * throttle));
    }

    public void AddForceLeft(float throttle)
    {
        _rigidbody.AddForce(Vector3.left * (OtherThrust * throttle));
    }
}