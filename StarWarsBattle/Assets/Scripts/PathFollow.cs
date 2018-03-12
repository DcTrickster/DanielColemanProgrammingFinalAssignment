using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour 
{


	public GameObject waypointManagerObj;
	private WaypointManager waypointManage;
	GameObject destination;
	public const float proxyDist = 0.5f;
	public const float decelerationFactor = 0.5f;
	Vector3 source;
	Vector3 target;
	Vector3 directionToDestination;
	Vector3 velocityToDestination;
	float distanceToDestination;
	float speed;


	Vector3 lookDirection; 
	public float turnSpeed;
	public float moveSpeed;

	public GameObject deathExplosion;
	public float HP = 10;

	// Use this for initialization
	void Awake () 
	{
		waypointManage = waypointManagerObj.GetComponent<WaypointManager> ();
		destination = waypointManage.NextWaypoint (null);
//		deathExplosion.SetActive (false);

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		source = transform.position;
		target = destination.transform.position;

		if (Vector3.Distance (source, target) < proxyDist) 
		{
			destination = waypointManage.NextWaypoint (destination);
		}

		lookDirection = target - source;
		Quaternion rotate = Quaternion.LookRotation (lookDirection.normalized);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotate, Time.deltaTime * turnSpeed);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotate, Time.deltaTime * turnSpeed);
		transform.Translate (new Vector3 (0, 0, moveSpeed) * Time.deltaTime);
	}

	void Arrive ()
	{

		if (Vector3.Distance (source, target) < proxyDist) 
		{
			destination = waypointManage.NextWaypoint (destination);
		}

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Bullet" && this.gameObject.tag == "Rebels") 
		{
			print ("I've Been Hit!");
			HP--;
			if (HP == 0) 
			{
				deathExplosion.SetActive (true);
				Invoke ("Destroyed", 1);
			}
		}
	}

	public void Destroyed()
	{
		Destroy (this.gameObject);
	}

}
