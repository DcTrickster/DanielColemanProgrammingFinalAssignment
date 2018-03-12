using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour 
{

	public float damage;
	public GameObject deathExplosion;
	public float HP = 10;

	// Use this for initialization
	void Start () 
	{
		
//		deathExplosion.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Bullet" && this.gameObject.tag == "Rebels") 
		{
			print ("I've Been Hit!");
			HP --;
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
