using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour {
	private GameObject BP_FindVGUI;
	private VGUI BP_VGUI;

	// Use this for initialization
	void Start () {

		BP_FindVGUI = GameObject.Find("Inventory");
		BP_VGUI = BP_FindVGUI.GetComponent<VGUI>();	
	}
	
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			if (this.gameObject.tag.Equals("BlockOne"))
			{
				BP_VGUI.V_BlockOnePlayerChange();
			}
			else if(this.gameObject.tag.Equals("BlockTwo"))
			{
				BP_VGUI.V_BlockTwoPlayerChange();
			}
		}
	}

	private void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			if (this.gameObject.tag.Equals("BlockOne"))
			{
				BP_VGUI.V_BlockOnePlayerChange();
			}
			else if (this.gameObject.tag.Equals("BlockTwo"))
			{
				BP_VGUI.V_BlockTwoPlayerChange();
			}
		}
	}
}
