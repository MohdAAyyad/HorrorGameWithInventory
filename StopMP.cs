using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMP : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col)
	{
		//Empty if statement here to make sure the collider stops the playfrom ONLY when the player is not on it
		if(col.gameObject.tag.Equals("Player"))
		{
			col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);

		}
		else if((col.gameObject.tag.Equals("MovingPlatform")) || (col.gameObject.tag.Equals("MovingPlatformUp")))
		{
			Debug.Log("Hey stop");
			col.SendMessage("MP_Stop");	
		}
	}

}
