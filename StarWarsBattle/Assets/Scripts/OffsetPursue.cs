using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : SteeringBehavior 
{

	public Boid leader;
	private Vector3 offset;
	Vector3 worldTarget;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - leader.transform.position;
		offset = Quaternion.Inverse(leader.transform.rotation) * offset;
	}
	
	public override Vector3 Calculate()
	{
		worldTarget = leader.transform.TransformPoint (offset);
		float dist = Vector3.Distance (worldTarget, transform.position);
		float time = dist / boid.maxSpeed;

		Vector3 targetPos = worldTarget + (leader.velocity * time);
		return boid.ArriveForce (targetPos, 10);
	}
}
