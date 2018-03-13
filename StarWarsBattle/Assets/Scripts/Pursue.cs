using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class Pursue : SteeringBehavior 
{

	public Boid target;
	Vector3 targetPos;

	Vector3 lookDirection; 
	public float turnSpeed;
	public float moveSpeed;


	public override Vector3 Calculate ()
	{
		float dist = Vector3.Distance (target.transform.position, transform.position);
		float time = dist / boid.maxSpeed;
		targetPos = target.transform.position + (time * target.velocity);
		return boid.SeekForce (targetPos);

	}
}
