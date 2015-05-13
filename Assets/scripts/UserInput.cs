using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{
    public GameObject PlayerObject;
    private Ship _playerShip;
    public GameObject CameraObject;
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
    }
}
