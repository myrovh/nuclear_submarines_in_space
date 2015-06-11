using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
public class ShipCamera : MonoBehaviour
{
    public Transform Target;
    public float XSensitivity;
    public float YSensitivity;

    public bool IsFreeLook = false;
    private float _rotationX;
    private float _rotationY;

    //TODO change isfreelook to use a function. on function call store rotation and fix it in place so camera rotates around that location instead of the object
    private void Update()
    {
        if (!IsFreeLook)
        {
            transform.LookAt(Target);
            transform.parent.rotation = Target.rotation;
            transform.rotation = Target.rotation;
        }
        else
        {
            _rotationX += Input.GetAxis("Mouse X")*XSensitivity;
            _rotationY += Input.GetAxis("Mouse Y")*YSensitivity;

            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, Vector3.right);

            transform.parent.localRotation = yQuaternion*xQuaternion;
        }
    }
}