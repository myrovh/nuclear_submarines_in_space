using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
public class ShipCamera : MonoBehaviour
{
    public bool IsFreeLook = false;
    public Transform Target;

    private void Update()
    {
        if (!IsFreeLook)
        {
            transform.LookAt(Target);
            transform.rotation = Target.rotation;
        }
    }
}