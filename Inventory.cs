using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	//The list which contains what items the player actually has at the moment
	private List<InventoryItem> IN_Item = new List<InventoryItem>();

	//Create a dictionary of InventoryItem objects which can be indexed using a string.
	//The idea is: we create a database of InventoryItem objects and we index this database using their names

	private Dictionary<string,InventoryItem> IN_InventoryDictionary = new Dictionary<string,InventoryItem>();

	//Create a new preset of the item and store it in the database
	private void IN_SetPreset(string Name, InventoryItem Preset)
	{
		IN_InventoryDictionary[Name] = Preset;
	}

	public void IN_AddNewItem(string Name)
	{
		//Get the preset information.
		//Preset information is hardcoded in the Start function
		//It's like getting data from a database which already has all of its data written.

		InventoryItem ItemToAdd = new InventoryItem(IN_InventoryDictionary[Name]);

		IN_Item.Add(ItemToAdd);
		Debug.Log("Hey from the inventory " + ItemToAdd.IT_GetUsable());
	}


	//Return item stored at a specific index if there are items to begin with
	public InventoryItem IN_GetItemAtIndex(int ItemToReturnIndex)
	{
		if (IN_Item.Count > 0)
		{
			return IN_Item[ItemToReturnIndex];
		}
		else
		{
			return null;
		}
	}

	//Remove the item from the inventory if there are items to being with
	public void IN_RemoveItemFromInventory(string ItemToRemoveName)
	{

		Debug.Log("Remove this: " + ItemToRemoveName);
		
			for (int i = 0; i < IN_Item.Count; i++)
			{
				if (IN_Item[i].IT_GetName() == ItemToRemoveName)
				{
					Debug.Log(IN_Item[i].IT_GetName() + " Removed");
					IN_Item.RemoveAt(i);
					break;

				}
			}
		
	}

	//return item count
	public int IN_ItemCount()
	{
		return IN_Item.Count;
	}


	//On start, create the database and do not destory this object
	private void Start()
	{
		DontDestroyOnLoad(gameObject);

		InventoryItem Item = new InventoryItem("Key", false);
		IN_SetPreset("Key", Item);
		Item = new InventoryItem("Key2", false);
		IN_SetPreset("Key2", Item);
		Item = new InventoryItem("UTorch", true);
		IN_SetPreset("UTorch", Item);
	}



}

