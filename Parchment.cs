using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchment : MonoBehaviour {

	private bool PA_PlayerEntered;
	private GameObject PA_FindGUI;

	//Get the GUI elements
	private VGUI PA_VGUI;

	//Get parchment name that the palyer is in contact with
	private string P_ParchmentNameOnContactWithPlayer;



	// Use this for initialization
	void Start()
	{
		PA_FindGUI = GameObject.Find("Inventory");
		PA_VGUI = PA_FindGUI.GetComponent<VGUI>();

		PA_PlayerEntered = false;



	}

	// Update is called once per frame
	void Update()
	{


		if (PA_PlayerEntered)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				PA_UseParchment();

			}
		}


	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			PA_PlayerEntered = true;
			PA_VGUI.V_EToInteractTrue();
			PA_VGUI.V_IsThePlayerInRangeCheck(true);
		}

	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			PA_PlayerEntered = false;
			PA_VGUI.V_EToInteractFalse();
			PA_VGUI.V_IsThePlayerInRangeCheck(false);

		}
	}

	private void PA_UseParchment()
	{
		PA_VGUI.V_ParchmentTorch(this.gameObject.tag);
		PA_VGUI.V_EToInteractFalse();
	}
}
