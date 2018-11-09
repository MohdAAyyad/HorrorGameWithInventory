using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLever : MonoBehaviour {

	private bool GL_PlayerEntered;
	private bool GL_Activated;
	private GameObject GL_FindLight;
	private ItemLight GL_Light;
	Vector3 GL_Scale;

	//GUI variables for sending messages to the player

	private GameObject GL_FindGUI;
	private VGUI GL_VGUI;
	

	// Use this for initialization
	void Start()
	{
		GL_PlayerEntered = false;
		GL_Scale = transform.localScale;
		GL_Activated = false;

		GL_FindLight = GameObject.Find("Lever_Light");
		GL_Light = GL_FindLight.GetComponent<ItemLight>();

		GL_FindGUI = GameObject.Find("Inventory");
		GL_VGUI = GL_FindGUI.GetComponent<VGUI>();


	}

	// Update is called once per frame
	void Update()
	{


		if (GL_PlayerEntered && !GL_Activated)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				//Flip the lever.
				GL_Scale.x *= -1;
				transform.localScale = GL_Scale;
				GL_Activated = true;
				//Turn off the light
				GL_Light.L_ActivatedChange();
				SendMessageUpwards("G_OpenUp");
				GL_VGUI.V_EToInteractFalse();
			}
		}


	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			GL_PlayerEntered = true;
			GL_VGUI.V_EToInteractTrue();
		}

	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			GL_PlayerEntered = false;
			GL_VGUI.V_EToInteractFalse();

		}
	}
}
