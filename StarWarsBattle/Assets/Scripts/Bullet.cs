﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		Invoke ("Destroy", 3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Destroy()
	{
		Destroy (this.gameObject);
	}

}
