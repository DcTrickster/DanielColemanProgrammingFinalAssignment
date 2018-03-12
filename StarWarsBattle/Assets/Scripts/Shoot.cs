using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{

	public GameObject bullet;
	public int shootSpeed;
	public float maxDist;
	public bool recharging = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		if (Physics.Raycast (this.transform.position, fwd, maxDist)) 
		{
			if (recharging == false) 
			{
				print ("PewPew!");
				GameObject bulletClone = GameObject.Instantiate (bullet, this.transform.position, Quaternion.Euler (new Vector3 (90, 0, 1))) as GameObject;
				bulletClone.GetComponent<Rigidbody> ().AddForce (transform.forward * shootSpeed);
				StartCoroutine (recharge ());

			}
		}
		
	}

	public IEnumerator recharge()
	{
		int randomCharge = Random.Range (2, 6);
		
		recharging = true;
		yield return new WaitForSeconds (randomCharge);
		recharging = false;
	}
}
