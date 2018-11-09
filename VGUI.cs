using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VGUI : MonoBehaviour {

	private Rect V_DrawRect;
	private bool V_ShowInv;
	private GameObject V_FindInv;
	private Inventory V_Inventory;
	private string V_ItemName;
	private bool V_ItemUsable;
	private Texture2D V_TextureToShow;
	private Vector2 V_RectSize;
	private bool V_RemoveItemState;
	private bool V_UseItemState;
	private bool V_UseParchmentTorch;
	private bool V_UseParchmentPuzzle;
	private Rect V_DrawRectParchment;

	//Bools used to show different messages on screen
	private bool V_BlockOnePlayerCheck;
	private bool V_BlockTwoPlayerCheck;
	private bool V_TalkingTreeCheck;
	private bool V_EToPickUp;
	private bool V_EToInteract;
	private bool V_NoKey;
	private bool V_IsThePlayerStillInRange;


	// Use this for initialization
	void Start () {

		V_DrawRect = new Rect(Screen.width /32, Screen.height/32 , 100,  75);
		V_DrawRectParchment= new Rect(Screen.width / 16, Screen.height / 16, Screen.width, Screen.height/4);

		V_ShowInv = false;

		//Find the inventory
		V_FindInv = GameObject.Find("Inventory");
		V_Inventory = V_FindInv.GetComponent<Inventory>();
		
		//GUI Rect size
		V_RectSize = new Vector2(50, 50);

		//Booleans used to know in which state we currently are
		V_RemoveItemState = false;
		V_UseItemState = false;

		//Booleans used to determine which parchment content to show
		V_UseParchmentTorch = false;
		V_UseParchmentPuzzle = false;

		//UI messages to the player
		V_BlockOnePlayerCheck = false;
		V_BlockTwoPlayerCheck = false;
		V_TalkingTreeCheck = false;
		V_EToInteract = false;
		V_EToPickUp = false;
		V_NoKey = false;
		V_IsThePlayerStillInRange = false;




	}
	
	// Update is called once per frame
	void Update () {
		//Only show inventory when the player presses I, and when the player is not viewing a parchment
		if (!V_UseParchmentTorch)
		{

			if (Input.GetKeyDown(KeyCode.I))
			{
				V_ShowInv = !V_ShowInv;
			}

			//Don't dispaly the inventory if there are not items
			if (V_Inventory.IN_ItemCount() <= 0)
			{
				V_ShowInv = false;
			}

			//Only if player presses R and the inventory is being shown, toggle the removal state
			if (Input.GetKeyDown(KeyCode.R))
			{
				if (V_ShowInv)
				{
					V_RemoveItemState = !V_RemoveItemState;

					//You can be in either use or remove state, but not both at the same time
					if (V_RemoveItemState)
					{
						V_UseItemState = false;
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.U))
			{
				if (V_ShowInv)
				{
					//You can be in either use or remove state, but not both at the same time
					V_UseItemState = !V_UseItemState;
					if (V_UseItemState)
					{
						V_RemoveItemState = false;
					}
				}
			}
		}

	}

	private void OnGUI()
	{
		
		//Only show inventory when the player presses I
		//And only when items exist in the inventory
		//Also show inventory normally when we don't want to remove items, and zoom in if we want to.
		if (V_ShowInv)
		{
			if(V_Inventory.IN_ItemCount() > 0 && !V_RemoveItemState)
			{
				V_ShowInventory();
			}

			if(V_RemoveItemState)
			{
				V_ShowInventoryForRemoval();
			}
			if(V_UseItemState)
			{
				V_ShowUsableItems();
			}

			

		}

		if(V_UseParchmentTorch)
		{
			
			GUI.Box(V_DrawRectParchment, "Tome of the Ancients Vartok 7:28 Thalia was cornered against a wall.The Archdemon Moloch had her cornered.\n\n\n" +
				"Until the true light howed her the way across the void \n\n\n" +
										 "Press (B) to go back");
			if(Input.GetKeyDown(KeyCode.B))
			{
				Debug.Log("Nani");
				V_UseParchmentTorch = false;
				if (V_IsThePlayerStillInRange)
				{
					V_EToInteractTrue();
				}
			}
		}

		else if(V_UseParchmentPuzzle)
		{
			V_DrawRectParchment = new Rect(Screen.width / 16, Screen.height / 16, Screen.width, Screen.height / 2);

			GUI.Box(V_DrawRectParchment, "You've found a torn parchment, you can make out a few sentences\n\n" +
										 "How long have I been trapped here?...\n\n" +
										 "Sacrifice?...Yes, that woman spoke of a sacrifice? For whom? Why me?...\n\n" +
										 "When did it start? The last thing I remember: green fields...dead bodies, blood everywhere\n\n" +
										 "Yet, I remember the sky was clear, it was a beautiful day, a beautiful day full of dread...\n\n" +
										 "Then darkness, nothingness....I woke up here, in this God forsaken place... I want out...Please...\n\n" +
										 "Press (B) to go back");

			if (Input.GetKeyDown(KeyCode.B))
			{
				V_UseParchmentPuzzle = false;
				if (V_IsThePlayerStillInRange)
				{
					V_EToInteractTrue();
				}
			}
		}
		else if (V_BlockOnePlayerCheck)
		{
			GUI.Box(V_DrawRectParchment, "There's no running away, my dear. Please proceed to your demise.");
		}
		else if (V_BlockTwoPlayerCheck)
		{
			GUI.Box(V_DrawRectParchment, "Wrong way, dear. Your demise is waiting for you in the opposite direction.\n We wouldn't want to let it wait, now would we?");
		}
		else if (V_TalkingTreeCheck)
		{
			GUI.Box(V_DrawRectParchment, "You will die painfully, girl. You should've taken the easy way out when you had the chance");
		}
		else if (V_EToPickUp)
		{
			GUI.Label(V_DrawRectParchment, "Press (E) to pick up");
		}
		else if (V_EToInteract)
		{
			GUI.Label(V_DrawRectParchment, "Press (E) to interact");
		}
		else if (V_NoKey)
		{
			GUI.Box(V_DrawRectParchment, "The door is locked...I wonder if there's a key lying somewhere...\n" +
										 "Press (B) to go back ");
			if(Input.GetKeyDown(KeyCode.B))
				{
				V_NoKeyChange();
				if (V_IsThePlayerStillInRange)
				{
					V_EToInteractTrue();
				}
				}
		}
	}

	private void V_ShowInventory()
	{
		for (int i = 0; i < V_Inventory.IN_ItemCount(); i++)
		{
			//Get the name of the item and display it
			V_ItemName = V_Inventory.IN_GetItemAtIndex(i).IT_GetName();
			V_ItemUsable = V_Inventory.IN_GetItemAtIndex(i).IT_GetUsable();
			if (!V_UseItemState)
			{
				V_TextureToShow = Resources.Load("Textures/" + V_ItemName, typeof(Texture2D)) as Texture2D;
				V_DrawRect = new Rect(Screen.width / 32 + (V_RectSize.x * i), Screen.height / 32, V_RectSize.x, V_RectSize.y);
				GUI.Box(V_DrawRect, "");
				GUI.DrawTexture(V_DrawRect, V_TextureToShow);
			}
		}
	}

	private void V_ShowInventoryForRemoval()
	{
		for (int i = 0; i < V_Inventory.IN_ItemCount(); i++)
		{
			//Get the name of the item and display it
			V_ItemName = V_Inventory.IN_GetItemAtIndex(i).IT_GetName();
			V_TextureToShow = Resources.Load("Textures/" + V_ItemName, typeof(Texture2D)) as Texture2D;
			V_DrawRect = new Rect(Screen.width / 32 + (V_RectSize.x * 1.5f * i), Screen.height / 32, V_RectSize.x * 1.5f, V_RectSize.y * 1.5f);
			GUI.Box(V_DrawRect, "");
			GUI.DrawTexture(V_DrawRect, V_TextureToShow);
			//Display numbers next to the displayed items to let the player know which buttons drop which items
			V_DrawRect = new Rect(Screen.width / 32 + (V_RectSize.x * 1.5f * i), Screen.height / 32 - 10, V_RectSize.x * 1.5f, V_RectSize.y * 1.5f);
			GUI.Box(V_DrawRect, (i+1).ToString());
		}
	}
	private void V_ShowUsableItems()
	{

		for (int i = 0; i < V_Inventory.IN_ItemCount(); i++)
		{
			//Get the name of the item and display it in a larger box if it is usable
			V_ItemName = V_Inventory.IN_GetItemAtIndex(i).IT_GetName();
			V_ItemUsable = V_Inventory.IN_GetItemAtIndex(i).IT_GetUsable();


			if (V_ItemUsable)
			{
				V_TextureToShow = Resources.Load("Textures/" + V_ItemName, typeof(Texture2D)) as Texture2D;
				V_DrawRect = new Rect(Screen.width / 32 + (V_RectSize.x * 1.5f * i), Screen.height / 32, V_RectSize.x * 1.5f, V_RectSize.y * 1.5f );
				GUI.Box(V_DrawRect, "");
				GUI.DrawTexture(V_DrawRect, V_TextureToShow);
				//Display numbers next to the displayed items to let the player know which buttons use which items
				V_DrawRect = new Rect(Screen.width / 32 + (V_RectSize.x * 1.5f * i), Screen.height / 32 - 10, V_RectSize.x * 1.5f, V_RectSize.y * 1.5f);
				GUI.Box(V_DrawRect, (i + 1).ToString());
			}
		}
	}

	//Check which parchment is being viewed
	public void V_ParchmentTorch(string ParchmentName)
	{ 
		if(ParchmentName == "ParchmentTorch")
		{
			V_UseParchmentTorch = true;
		}
		else if(ParchmentName == "ParchmentPuzzle")
		{
			V_UseParchmentPuzzle = true;
		}
	}

	public bool V_AreWeInRemoveItem()
	{
		return V_RemoveItemState;
	}

	public bool V_AreWeInUseItem()
	{
		return V_UseItemState;
	}

	//Used to reset the state of the inventory.
	//This way if the player removes or uses an item, the inventory "turns off" and we go back to the idle state
	public void V_ResetState()
	{
		V_ShowInv = false;
		V_RemoveItemState = false;
		V_UseItemState = false;
	}

	public void V_BlockOnePlayerChange()
	{
		V_BlockOnePlayerCheck = !V_BlockOnePlayerCheck;

	}
	public void V_BlockTwoPlayerChange()
	{
		V_BlockTwoPlayerCheck = !V_BlockTwoPlayerCheck;

	}

	public void V_TalkingTreeChange()
	{
		V_TalkingTreeCheck = !V_TalkingTreeCheck;
	}

	public void V_EToInteractTrue()
	{
		V_EToInteract = true;
	}
	public void V_EToInteractFalse()
	{
		V_EToInteract = false;
	}
	public void V_EToPickupTrue()
	{
		V_EToPickUp = true;
	}
	public void V_EToPickupFalse()
	{
		V_EToPickUp = false;
	}
	public void V_NoKeyChange()
	{
		V_NoKey = !V_NoKey;
	}
	public void V_IsThePlayerInRangeCheck( bool state)
	{
		V_IsThePlayerStillInRange = state;
	}

}
