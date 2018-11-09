using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	private Rigidbody2D MP_RigidBody;
	//Bool used to stop the platform moving upwards.
	//We need this because the platform will collide with the StopPlatform object causing an exit trigger with the player
	//While the player is still actually on the platform which means the player and the platform will collide again causing
	//the platform to go up again.
	//This bool becomes true when the platform collides with the StopPlatform object so that when it collides with the player again
	//It does not go up again.

	private bool MP_UpStop;
	// Use this for initialization
	void Start () {
		MP_RigidBody = gameObject.GetComponent<Rigidbody2D>();
		MP_UpStop = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void MP_Stop()
	{
		//MP_RigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
		MP_RigidBody.velocity = new Vector2(0.0f, 0.0f);
		//True when you hit the first StopPlatform object (Top).
		//False when you hit the second StopPlatform object (Bottom).
		MP_UpStop = !MP_UpStop;
	}


	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			col.transform.parent = this.transform;
			//col.rigidbody.isKinematic = true;
			if (gameObject.tag.Equals("MovingPlatform"))
			{
				MP_RigidBody.velocity = new Vector2(0.0f, -2.0f);
				col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			}
			else if ((gameObject.tag.Equals("MovingPlatformUp")) && MP_UpStop == false)
			{
				MP_RigidBody.velocity = new Vector2(0.0f, 2.0f);
				col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			}
		}

	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			if (gameObject.tag.Equals("MovingPlatform"))
			{
				col.transform.parent = null;
				MP_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
				//col.rigidbody.isKinematic = false;
				MP_RigidBody.velocity = new Vector2(0.0f, 2.0f);
				col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

			}
			else if (gameObject.tag.Equals("MovingPlatformUp"))
			{
				col.transform.parent = null;
				MP_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
				//col.rigidbody.isKinematic = false;
				MP_RigidBody.velocity = new Vector2(0.0f, -2.0f);
				col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

			}
		}
	}
}
