using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBoid : MonoBehaviour 
{
	List<SteeringBehavior> behaviors = new List<SteeringBehavior>();

	public Vector3 force = Vector3.zero;
	public Vector3 acceleration = Vector3.zero;
	public Vector3 velocity = Vector3.zero;
	public float mass = 1f;
	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () 
	{
		SteeringBehavior[] behaviors = GetComponents<SteeringBehavior>();
		foreach (SteeringBehavior b in behaviors) 
		{
			this.behaviors.Add (b);
		}
	}

	public Vector3 FleeForce(Vector3 target, float slowingDist = 15f, float deceleration = 1f)
	{
		Vector3 toTarget = target - transform.position;
		float distance = toTarget.magnitude;

		if (distance == 0)
		{
			return Vector3.zero;
		}

		float ramped = maxSpeed * (distance / (slowingDist * deceleration));
		float clamped = Mathf.Min (ramped, maxSpeed);
		Vector3 desired = clamped * (toTarget/distance);

		return  velocity - desired;
	}

	// Update is called once per frame
	void Update () 
	{
		force = Calculate ();
		Vector3 newAcceleration = force / mass;

		float smoothRate = Mathf.Clamp (9f * Time.deltaTime, 0.15f, 0.4f) / 2f;
		acceleration = Vector3.Lerp (acceleration, newAcceleration, smoothRate);

		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;
	}

	Vector3 Calculate()
	{
		force = Vector3.zero;

		foreach (SteeringBehavior b in behaviors) 
		{
			if (b.isActiveAndEnabled) 
			{
				force += b.Calculate () * b.weight;
			}
		}

		return force;
	}
}
