using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

	private string IT_Name;
	private bool IT_Usable;

	public InventoryItem(InventoryItem ItemToCopy)
	{
		IT_Name = ItemToCopy.IT_GetName();
		IT_Usable = ItemToCopy.IT_GetUsable();
	}

	public InventoryItem(string ItemName, bool ItemUsable)
	{
		IT_Name = ItemName;
		IT_Usable = ItemUsable;

		Debug.Log(IT_Name + " " + IT_Usable);
	}

	public string IT_GetName()
	{
		return IT_Name;
	}

	public bool IT_GetUsable()
	{
		return IT_Usable;
	}
}
