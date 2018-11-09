using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	Rigidbody2D G_RigidBody;
	
	//Get player position variables
	private GameObject G_FindPlayer;
	private PlayerController G_Player;
	private Vector2 G_PlayerPosition;

	//Set enemy data
	private Vector2 G_EnemyPosition;
	public GameObject G_EnemyToInstantiate;



	// Use this for initialization
	void Start()
	{
		G_RigidBody = GetComponent<Rigidbody2D>();

		if (G_FindPlayer = GameObject.Find("Player_NoSpotLight"))
		{
			G_Player = G_FindPlayer.GetComponent<PlayerController>();

			G_PlayerPosition = new Vector2(G_Player.P_GetPosition().x, G_Player.P_GetPosition().y);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (G_FindPlayer = GameObject.Find("Player_NoSpotLight"))
		{
			G_PlayerPosition = new Vector2(G_Player.P_GetPosition().x, G_Player.P_GetPosition().y);
		}
	}

	private void G_StopRightThere()
	{
		//Zero out the velocity and the gravity of the boulder once it hits the stop boulder trigger
		G_RigidBody.gravityScale = 0.0f;
		G_RigidBody.velocity = new Vector2(0.0f, 0.0f);

		//Instantiate enemy once the gate stops
		G_EnemyPosition = new Vector2(G_PlayerPosition.x - Enemy.E_HowFarAway, G_PlayerPosition.y);

		GameObject G_NewEnemy = (GameObject)Instantiate(G_EnemyToInstantiate, G_EnemyPosition, Quaternion.Euler(0f, 0f, 0f));
	}

	private void G_OpenUp()
	{
		G_RigidBody.gravityScale = 0.0f;
		G_RigidBody.velocity = new Vector2(0.0f, 3.0f);
	}
}
