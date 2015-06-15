using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
    public void SwitchToGame()
    {
        Application.LoadLevel("test_solar_system");
    }
}
