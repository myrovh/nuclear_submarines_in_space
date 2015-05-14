using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

[UsedImplicitly]
public class Ship : MonoBehaviour
{
    public float ForwardThrust = 10.0f;
    public float OtherThrust = 1.0f;
    public float ControlThrust = 1.0f;
    public float RotationArrestSpeed = 10.0f;
    private Rigidbody _rigidbody;

	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	}

    public void AddForceForward(float throttle)
    {
        _rigidbody.AddRelativeForce(Vector3.forward * (ForwardThrust * throttle));
    }

    public void AddForceBackwards(float throttle)
    {
        _rigidbody.AddRelativeForce(-Vector3.forward * (ForwardThrust * throttle));
    }

    public void AddForceRight(float throttle)
    {
        _rigidbody.AddRelativeForce(Vector3.right * (OtherThrust * throttle));
    }

    public void AddForceLeft(float throttle)
    {
        _rigidbody.AddRelativeForce(Vector3.left * (OtherThrust * throttle));
    }

    public void AddForceUp(float throttle)
    {
        _rigidbody.AddRelativeForce(Vector3.up * (OtherThrust * throttle));
    }

    public void AddForceDown(float throttle)
    {
        _rigidbody.AddRelativeForce(Vector3.down * (OtherThrust * throttle));
    }

    public void AddForceXyRotation(float horizontal, float vertical)
    {
        _rigidbody.AddRelativeTorque(transform.up * (horizontal * ControlThrust));
        _rigidbody.AddRelativeTorque(transform.right * (vertical * ControlThrust));
    }

    public void AddForceAxisRotation(bool isPositive)
    {
        if (isPositive)
        {
            _rigidbody.AddRelativeTorque(transform.forward*ControlThrust);
        }
        else
        {
            _rigidbody.AddRelativeTorque(transform.forward*-ControlThrust);
        }
    }

    public void ClampTorqueForce()
    {
        Vector3 reveseRotation = -_rigidbody.angularVelocity;
        _rigidbody.AddRelativeTorque(reveseRotation * RotationArrestSpeed);
    }
}