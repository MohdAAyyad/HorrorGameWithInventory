using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBlue : MonoBehaviour {

	private bool L_PlayerEntered;
	private bool L_Activated;
	private GameObject L_FindLight;
	private ItemLight L_Light;
	Vector3 L_Scale;


	// Use this for initialization
	void Start()
	{
		L_PlayerEntered = false;
		L_Scale = transform.localScale;
		L_Activated = false;

		L_FindLight = GameObject.Find("Lever_Light_Blue");
		L_Light = L_FindLight.GetComponent<ItemLight>();

		L_Light.L_Reset();


	}

	// Update is called once per frame
	void Update()
	{


		if (L_PlayerEntered && !L_Activated)
		{

			if (Input.GetKeyDown(KeyCode.E))
			{
				//Flip the lever.
				L_Scale.x *= -1;
				transform.localScale = L_Scale;
				L_Activated = true;
				//Turn off the light
				L_Light.L_ActivatedChange();
				SendMessageUpwards("PC_LightBlue");
			}
		}


	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			L_PlayerEntered = true;
		}

	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			L_PlayerEntered = false;

		}
	}

	public void L_Reset()
	{
		L_PlayerEntered = false;
		L_Activated = false;
		L_Scale.x *= -1;
		transform.localScale = L_Scale;
		//L_Light.L_ActivatedChange();

	}
}
