using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour 
{
	int nextPoint;
	public GameObject[] waypoints;
	//	public Vector3[] waypointsPos;
	private Vector3 currentPos;




	public GameObject NextWaypoint (GameObject current)
	{
		if (current != null) {
			for (int i = 0; i < waypoints.Length; i++) {
				if (current == waypoints [i]) {
					nextPoint = (i + 1) % waypoints.Length;
				}
			}
		} 
		else 
		{
			nextPoint = 0;
		}
		return waypoints [nextPoint];
	}
	//
	//	void OnDrawGizmos()
	//	{
	//		for (int i = 0; i < waypoints.Length; i++)
	//		{
	//				Gizmos.DrawLine (waypoints[i].transform.position, waypoints[i+i].transform.position);
	//				Gizmos.color = Color.green;
	//		}
	//	}
}
