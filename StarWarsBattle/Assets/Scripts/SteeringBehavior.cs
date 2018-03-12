using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;

public abstract class SteeringBehavior : MonoBehaviour 
{
	public float weight = 1f;
	public Vector3 force;

	[HideInInspector]
	public Boid boid;

	// Use this for initialization
	void Awake ()
	{
		boid = GetComponent<Boid> ();
	}

	public abstract Vector3 Calculate();

}
