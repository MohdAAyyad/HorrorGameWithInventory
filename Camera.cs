using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	private GameObject C_FindPlayer;
	private PlayerController C_Player;


	// Use this for initialization
	void Start () {

		if(C_FindPlayer=GameObject.Find("Player_NoSpotLight"))
		{
			C_Player = C_FindPlayer.GetComponent<PlayerController>();
		}
		
	}
	
	// Update is called once per frame
	void Update () {


		if (C_FindPlayer = GameObject.Find("Player_NoSpotLight"))
		{
			transform.position = new Vector3(C_Player.P_GetPosition().x, C_Player.P_GetPosition().y,-10.0f);
			

		}

	}
}
