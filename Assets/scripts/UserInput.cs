using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject CameraObject;
    public float DeadZone = 0.0f;
    private Ship _playerShip;
    private ShipCamera _cameraScript;

    void Start()
    {
        _playerShip = PlayerObject.GetComponent<Ship>();
        _cameraScript = CameraObject.GetComponent<ShipCamera>();
    }

	void Update ()
    {
        #region Camera Controls
        //Turns on free look while user presses 'c' key
        if (Input.GetKeyDown(KeyCode.C))
	    {
	        _cameraScript.IsFreeLook = true;
	    }

        //Disables free look when user releases 'c' key
	    if (Input.GetKeyUp(KeyCode.C))
	    {
	        _cameraScript.IsFreeLook = false;
        }
        #endregion

        PlayerShipControls();
    }

    void PlayerShipControls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _playerShip.AddForceLeft(1.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _playerShip.AddForceBackwards(1.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerShip.AddForceRight(1.0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _playerShip.AddForceForward(1.0f);
        }

        if (Input.GetKey((KeyCode.Space)))
        {
            _playerShip.AddForceUp(1.0f);
        }

        if (Input.GetKey((KeyCode.LeftControl)))
        {
            _playerShip.AddForceDown(1.0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _playerShip.AddForceAxisRotation(true);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _playerShip.AddForceAxisRotation(false);
        }

        if (Input.GetKey(KeyCode.R))
        {
            _playerShip.ClampTorqueForce();
        }

        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.C))
        {
            return;
        }
        _playerShip.AddForceXyRotation(Input.GetAxis("Mouse X"), 0.0f);
        _playerShip.AddForceXyRotation(0.0f, Input.GetAxis("Mouse Y"));
    }
}