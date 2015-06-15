using UnityEngine;
using System.Collections;

public class MissileShip : MonoBehaviour
{
    private Transform _pivot;
    private float countdown = 2.0f;
    public Transform _spawnPoint;
    public Transform target;
    public GameObject MissilePrefab;

	// Use this for initialization
	void Start ()
	{
	    _pivot = transform.parent;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //_pivot.rotation =
	      //  Quaternion.Euler(new Vector3(_pivot.rotation.x, _pivot.rotation.y + (2.0f*Time.deltaTime), _pivot.rotation.z));


        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            GameObject temp = (GameObject) Instantiate(MissilePrefab, _spawnPoint.position, Quaternion.identity);
            var script = temp.GetComponent<Missile>();
            script.Target = target;
            countdown = 1.0f;
        }
	}
}
