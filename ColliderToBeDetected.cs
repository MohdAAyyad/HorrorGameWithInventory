using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderToBeDetected : MonoBehaviour {

	private bool CBD_PlatformDetected;


	// Use this for initialization
	void Start () {

	gameObject.GetComponent<Collider2D>().enabled=false;
	CBD_PlatformDetected = false;


	}
	
	// Update is called once per frame
	void Update () {

		if(CBD_PlatformDetected)
		{
			gameObject.GetComponent<Collider2D>().enabled = true;
		}
		else
		{
			gameObject.GetComponent<Collider2D>().enabled = false;

		}

	}

	private void CBD_PlatformChangeState()
	{
		CBD_PlatformDetected = !CBD_PlatformDetected;

	}


}
