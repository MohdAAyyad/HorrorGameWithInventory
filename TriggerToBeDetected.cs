using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToBeDetected : MonoBehaviour {

	//If the player's torch is detected, enable the collider on top of the platforms, otherwise, delete it.
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("DetectPlatforms"))
		{
			
			SendMessageUpwards("CBD_PlatformChangeState");
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("DetectPlatforms"))
		{
			
			SendMessageUpwards("CBD_PlatformChangeState");
		}
	}


}
