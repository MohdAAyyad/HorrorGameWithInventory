using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	//Player data
	private GameObject E_FindPlayer;
	private PlayerController P_PlayerController;
	private Vector2 P_Position;

	//Enemy data
	private Vector2 E_Position;
	private Vector2 E_MoveToPlayerDirection;
	private Vector2 E_Velocity;
	private Rigidbody2D E_RigidBody;

	//Global variable
	//How far away from the player to instantiate the enemy
	public static float E_HowFarAway = 10.0f;
	private float E_TimeStep;

	private bool E_MoveAwayFromPlayerCheck;

	//Duration determines when the enemy object destroys itself
	//Direction determines the direction to where the enemy will go to stop pursuing the player
	private float E_MoveAwayDuration;
	private float E_MoveAwayDirection;


	// Use this for initialization
	void Start () {

		if (E_FindPlayer = GameObject.Find("Player_NoSpotLight"))
		{
			P_PlayerController = E_FindPlayer.GetComponent<PlayerController>();
			P_Position = P_PlayerController.P_GetPosition();
		}

		//Get enemy position

		E_RigidBody = GetComponent<Rigidbody2D>();
		E_Position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
		E_Velocity = E_RigidBody.velocity;

		E_TimeStep = 2.6316f;

		E_MoveAwayFromPlayerCheck = false;

		E_MoveAwayDuration = 5.0f;

		//Make sure the enemy's scale is correct
		if (P_Position.x - E_Position.x < 0)
		{
			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
		}



	}

	// Update is called once per frame
	void Update () {
		if (E_FindPlayer = GameObject.Find("Player_NoSpotLight"))
		{
			P_Position = P_PlayerController.P_GetPosition();
			E_Position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);

			if (!E_MoveAwayFromPlayerCheck)
			{
				E_MoveToPlayer();
			}
			else
			{
				E_MoveAway(E_MoveAwayDirection);
			}
		}
	}

	private void E_MoveToPlayer()
	{
		//Get displacement, normalize it, and apply a foce in its direction
		E_MoveToPlayerDirection = new Vector2(P_Position.x - E_Position.x, P_Position.y - E_Position.y);


		E_MoveToPlayerDirection.Normalize();
		//E_RigidBody.AddForce(E_MoveToPlayerDirection*0.5f);
		E_RigidBody.velocity = new Vector2((E_HowFarAway / E_TimeStep) * E_MoveToPlayerDirection.x, (E_HowFarAway / E_TimeStep) * E_MoveToPlayerDirection.y);
	}

	private void E_Stop()
	{
		//Stop the enemy from moving towards the player at a certain distance
		E_RigidBody.AddForce(new Vector2(0.0f, 0.0f));
		E_RigidBody.velocity = new Vector2(0.0f, 0.0f);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			Destroy(col.gameObject);
			E_Stop();
		}
	}

	private void E_MoveAway(float E_Direction)
	{
		E_RigidBody.velocity = new Vector2(3.0f, E_Direction);

		E_MoveAwayDuration -= Time.deltaTime;

		if(E_MoveAwayDuration<=0.0f)
		{
			Destroy(gameObject);
		}
	}

	public void E_MoveAwayCheckChange(float E_Direction)
	{
		E_MoveAwayDirection = E_Direction;
		E_MoveAwayFromPlayerCheck = true;
	}

}
