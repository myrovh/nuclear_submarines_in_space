using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

[UsedImplicitly]
public class Ship : MonoBehaviour
{
    public float ForwardThrust = 100.0f;
    public float OtherThrust = 100.0f;
    public float ControlThrust = 30.0f;
    public float RotationArrestSpeed = 1.0f;
    private Rigidbody _rigidbody;
    private Vector3 _updateTickForce;
    private Vector3 _updateTickRotation;

	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	    _updateTickForce = Vector3.zero;
	    _updateTickRotation = Vector3.zero;
	}

    void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(_updateTickForce);
        _rigidbody.AddTorque(_updateTickRotation);
        _updateTickForce = Vector3.zero;
        _updateTickRotation = Vector3.zero;

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        GameOver();
    }

    public void GameOver()
    {
        Application.LoadLevel("menu");
    }

    public void AddForceForward(float throttle)
    {
        _updateTickForce += Vector3.forward*(ForwardThrust*throttle*Time.deltaTime);
    }

    public void AddForceBackwards(float throttle)
    {
        _updateTickForce += -Vector3.forward*(ForwardThrust*throttle*Time.deltaTime);
    }

    public void AddForceRight(float throttle)
    {
        _updateTickForce += Vector3.right*(OtherThrust*throttle*Time.deltaTime);
    }

    public void AddForceLeft(float throttle)
    {
        _updateTickForce += Vector3.left*(OtherThrust*throttle*Time.deltaTime);
    }

    public void AddForceUp(float throttle)
    {
        _updateTickForce += Vector3.up*(OtherThrust*throttle*Time.deltaTime);
    }

    public void AddForceDown(float throttle)
    {
        _updateTickForce += Vector3.down*(OtherThrust*throttle*Time.deltaTime);
    }

    public void AddForceXyRotation(float horizontal, float vertical)
    {
        _updateTickRotation += transform.up*(horizontal*ControlThrust*Time.deltaTime);
        _updateTickRotation += -transform.right*(vertical*ControlThrust*Time.deltaTime);
    }

    public void AddForceAxisRotation(bool isPositive)
    {
        if (isPositive)
        {
            _updateTickRotation += transform.forward*ControlThrust*Time.deltaTime;
        }
        else
        {
            _updateTickRotation += transform.forward*-ControlThrust*Time.deltaTime;
        }
    }

    public void ClampTorqueForce()
    {
        if (_rigidbody.angularVelocity.magnitude > 0.0f)
        {
            Vector3 reveseRotation = -_rigidbody.angularVelocity;
            _updateTickRotation += reveseRotation*RotationArrestSpeed;
        }
    }
}