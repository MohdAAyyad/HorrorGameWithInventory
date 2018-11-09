using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingTree : MonoBehaviour {

	private GameObject TT_FindVGUI;
	private VGUI TT_VGUI;

	// Use this for initialization
	void Start()
	{

		TT_FindVGUI = GameObject.Find("Inventory");
		TT_VGUI = TT_FindVGUI.GetComponent<VGUI>();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			TT_VGUI.V_TalkingTreeChange();
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			TT_VGUI.V_TalkingTreeChange();
		}
	}
}
