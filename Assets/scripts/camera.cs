using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    public Transform Target;
    public bool is_free_look = false;

    private void Update()
    {
        if (!is_free_look)
        {
            transform.LookAt(Target);
            transform.rotation = Target.rotation;
        }
        else
        {
            //free look camera functions
        }
    }
}