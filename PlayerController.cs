/****************** KNOWN BUGS *******************************
 * [SOLVED] If player is touching the gate when it opens, they move with it so we activated Y constraints on collision with the gate but the rotation becomes no longer frozen
 * [SOLVED] Items instantiate only to the right of the player character
 * [SOLVED] The Use menu and Rmeove menu state variables do not change back to false after items are used or removed
 * When the puzzle resets, the lights do not flicker in sync
 * You can go to the USE menue even if there are no usable items, just add a box that says you're in the usable items menu
 * 
*/

/********************************** IDEAS ***************************
 * Need to make the system differentiate between usable items which are also removable, and quest items which are viewable but not removable
 * Make shift a counter based ability (like give the player only two "shifts")
 * Items that replenish stamina
 * Flags that are planted as checkpoints
 * Make her hair glow, seriously, do
 * If you have the time add a simple narrative choice in the game\
 * Have an after image of the character when she's running
 * Suggestion for an item --> Blue glowing butterflies which light the road ahead
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Rigidbody2D P_RigidBody;
	private float P_Horizontal;
	private float P_Speed;
	private bool P_FacingRight;
	private List<GameObject> P_Items;

	//Get the inventory
	private GameObject P_FindInventory;
	private Inventory P_Inventory;

	//Check if the player is in contact with an item
	private bool P_OnContactWithItem;
	//Check if the palyer is in contact with a locked door
	private bool P_OnContactWithLockedDoor;


	//Get item name that the palyer is in contact with
	private string P_ItemNameOnContactWithPlayer;

	//Used to destory the item from the scene once the player has picked it up
	private GameObject P_PickedUpItem;

	//Get the GUI elements
	private VGUI P_VGUI;

	//Animation
	private Animator P_Animator;

	//LockedDoor

	private GameObject P_FindLockedDoor;
	private LockedDoor P_LockedDoor;
	private bool P_DoorOpened;

	//Insntiate enemy when player picks up key

	public GameObject P_Enemy;
	private Vector2 P_EnemyPosition;








	// Use this for initialization
	void Start()
	{

		P_RigidBody = gameObject.GetComponent<Rigidbody2D>();
		P_Speed = 3.0f;
		P_FacingRight = true;
		P_Items = new List<GameObject>();

		//Find the player's inventory object

		P_FindInventory = GameObject.Find("Inventory");
		P_Inventory = P_FindInventory.GetComponent<Inventory>();
		P_VGUI = P_FindInventory.GetComponent<VGUI>();
		P_OnContactWithItem = false;
		P_ItemNameOnContactWithPlayer = "";
		P_PickedUpItem = null;

		P_Animator = gameObject.GetComponent<Animator>();

		P_OnContactWithLockedDoor = false;
		P_DoorOpened = false;








	}

	// Update is called once per frame
	void Update()
	{
		P_Animator.SetFloat("Speed", Mathf.Abs(P_Speed));  

		//Prevent the player's sprite from doing weird rotations upong colliding with objects (extra freeze rotation)
		gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

		P_Horizontal = Input.GetAxis("Horizontal");
		P_HandleMovement(P_Horizontal);
		P_Flip(P_Horizontal);

		//Run forest run
		if (Input.GetKey(KeyCode.LeftShift))
		{
			P_Speed = 4.0f;

			
		}
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			P_Speed = 3.0f;
		}
			//Only remove items when we are in remove item state
			if (P_VGUI.V_AreWeInRemoveItem())
			{
				P_RemoveItemFromInvetory();
			}
			//Only use items when we are in use items state
			if(P_VGUI.V_AreWeInUseItem())
			{
				P_UseItem();
			}

		//Player can only get items he's in contact with
		if (P_OnContactWithItem)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				P_AddToInventory(P_ItemNameOnContactWithPlayer);
			}
		}
		//Check if the player is within the boundaries of the locked door
		if (P_OnContactWithLockedDoor)
		{
			
			if (Input.GetKeyDown(KeyCode.E))
			{
				P_TryToOpenLockedDoor();
			}
		}




	}


	private void P_HandleMovement(float horizontal)
	{
		// Move the player body based on the horizontal value
	
		P_RigidBody.velocity = new Vector2(horizontal * P_Speed, P_RigidBody.velocity.y);
		P_Speed = Mathf.Abs(horizontal) * 3;
		
	

	}

	private void P_Flip(float horizontal)
	{
		if ((horizontal > 0 && !P_FacingRight || horizontal < 0 && P_FacingRight))
		{

			//Correct the facingRight condition.
			P_FacingRight = !P_FacingRight;

			//Flip the character using the scale attribute.
			Vector3 P_Scale = transform.localScale;
			P_Scale.x *= -1;
			transform.localScale = P_Scale;
		}
	}


	private void OnCollisionEnter2D(Collision2D col)
	{
		//Don't move with the gate
		if (col.gameObject.tag.Equals("Gate"))
		{
			P_RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
	

		}
	}

	private void OnCollisionExit2D(Collision2D col)
	{
		//Rever the change after moving away from the gate.
		if (col.gameObject.tag.Equals("Gate"))
		{
			P_RigidBody.constraints = RigidbodyConstraints2D.None;
			P_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		//Add the key to the player's inventory
		if (col.gameObject.tag.Equals("Key"))
		{
			P_OnContactWithItem = true;
			P_ItemNameOnContactWithPlayer = col.gameObject.tag;
			P_PickedUpItem = col.gameObject;
			P_VGUI.V_EToPickupTrue();

		}
		else if (col.gameObject.tag.Equals("Key2"))
		{
			P_OnContactWithItem = true;
			P_ItemNameOnContactWithPlayer = col.gameObject.tag;
			P_PickedUpItem = col.gameObject;
			P_VGUI.V_EToPickupTrue();

		}
		else if (col.gameObject.tag.Equals("UTorch"))
		{
			P_OnContactWithItem = true;
			P_ItemNameOnContactWithPlayer = col.gameObject.tag;
			P_PickedUpItem = col.gameObject;
			P_VGUI.V_EToPickupTrue();

		}


		else if(col.gameObject.tag.Equals("LockedDoor"))
		{
			P_OnContactWithLockedDoor = true;
			P_VGUI.V_EToInteractTrue();

			P_VGUI.V_IsThePlayerInRangeCheck(true);
		}

		else if (col.gameObject.tag.Equals("InstaEnemy"))
		{
			P_EnemyPosition = new Vector2(1.2f * (gameObject.transform.position.x - Enemy.E_HowFarAway), gameObject.transform.position.y);

			GameObject G_NewEnemy = (GameObject)Instantiate(P_Enemy, P_EnemyPosition, Quaternion.Euler(0f, 0f, 0f));
		}

	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Key"))
		{
			P_OnContactWithItem = false;
			P_VGUI.V_EToPickupFalse();
		}
		else if (col.gameObject.tag.Equals("Key2"))
		{
			P_OnContactWithItem = false;
			P_VGUI.V_EToPickupFalse();
		}
		else if (col.gameObject.tag.Equals("UTorch"))
		{
			P_OnContactWithItem = false;
			P_VGUI.V_EToPickupFalse();
		}
		else if(col.gameObject.tag.Equals("LockedDoor"))
		{
			P_OnContactWithLockedDoor = false;
			P_VGUI.V_EToInteractFalse();
			Debug.Log("No longer near the door");

			P_VGUI.V_IsThePlayerInRangeCheck(false);

		}
	}

	private void P_AddToInventory(string ItemToAddName)
	{

		P_Inventory.IN_AddNewItem(ItemToAddName);

		Destroy(P_PickedUpItem);
		P_VGUI.V_EToPickupFalse();

		if(ItemToAddName =="Key")
		{
			P_EnemyPosition = new Vector2(gameObject.transform.position.x - Enemy.E_HowFarAway, gameObject.transform.position.y);

			GameObject G_NewEnemy = (GameObject)Instantiate(P_Enemy, P_EnemyPosition, Quaternion.Euler(0f, 0f, 0f));
		}
	}

	private void P_RemoveItemFromInvetory()
	{

		//Check where to instantiate the items (to the left or to the right of the player)
		float P_WhereToInstantiate = 1.0f;
		if(P_FacingRight)
		{
			P_WhereToInstantiate = 1.0f;
		}
		else
		{
			P_WhereToInstantiate = -1.0f;
		}


		//Remove the items based on the player's choice
		if (P_Inventory.IN_ItemCount() > 0)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				GameObject P_RemovedItem = Resources.Load("Prefabs/" + P_Inventory.IN_GetItemAtIndex(0).IT_GetName(), typeof(GameObject)) as GameObject;
				Instantiate(P_RemovedItem, new Vector2(gameObject.transform.position.x + P_WhereToInstantiate, gameObject.transform.position.y), gameObject.transform.rotation);
				P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(0).IT_GetName());
				P_VGUI.V_ResetState();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				GameObject P_RemovedItem = Resources.Load("Prefabs/" + P_Inventory.IN_GetItemAtIndex(1).IT_GetName(), typeof(GameObject)) as GameObject;
				Instantiate(P_RemovedItem, new Vector2(gameObject.transform.position.x + P_WhereToInstantiate, gameObject.transform.position.y), gameObject.transform.rotation);
				P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(1).IT_GetName());
				P_VGUI.V_ResetState();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				GameObject P_RemovedItem = Resources.Load("Prefabs/" + P_Inventory.IN_GetItemAtIndex(2).IT_GetName(), typeof(GameObject)) as GameObject;
				Instantiate(P_RemovedItem, new Vector2(gameObject.transform.position.x + P_WhereToInstantiate, gameObject.transform.position.y), gameObject.transform.rotation);
				P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(2).IT_GetName());
				P_VGUI.V_ResetState();
			}
					   			 		  
		}
	}


	private void P_UseItem()
	{

		float P_WhereToInstantiate = 1.0f;
		if (P_FacingRight)
		{
			P_WhereToInstantiate = 1.0f;
		}
		else
		{
			P_WhereToInstantiate = -1.0f;
		}

		GameObject RemoveItem = null;

		//Use the items based on the player's choice if the items themselves are usable
		if (P_Inventory.IN_ItemCount() > 0)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (P_Inventory.IN_GetItemAtIndex(0).IT_GetUsable())
				{
					GameObject P_RemovedItem = Resources.Load("Prefabs/" + P_Inventory.IN_GetItemAtIndex(0).IT_GetName(), typeof(GameObject)) as GameObject;
					RemoveItem = Instantiate(P_RemovedItem, new Vector2(gameObject.transform.position.x + P_WhereToInstantiate, gameObject.transform.position.y), gameObject.transform.rotation);
					P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(0).IT_GetName());
					P_VGUI.V_ResetState();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (P_Inventory.IN_GetItemAtIndex(1).IT_GetUsable())
				{
					GameObject P_RemovedItem = Resources.Load("Prefabs/" + P_Inventory.IN_GetItemAtIndex(1).IT_GetName(), typeof(GameObject)) as GameObject;
					RemoveItem = Instantiate(P_RemovedItem, new Vector2(gameObject.transform.position.x + P_WhereToInstantiate, gameObject.transform.position.y), gameObject.transform.rotation);
					P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(1).IT_GetName());
					P_VGUI.V_ResetState();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (P_Inventory.IN_GetItemAtIndex(2).IT_GetUsable())
				{
					GameObject P_RemovedItem = Resources.Load("Prefabs/" + P_Inventory.IN_GetItemAtIndex(2).IT_GetName(), typeof(GameObject)) as GameObject;
					RemoveItem = Instantiate(P_RemovedItem, new Vector2(gameObject.transform.position.x + P_WhereToInstantiate, gameObject.transform.position.y), gameObject.transform.rotation);
					P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(2).IT_GetName());
					P_VGUI.V_ResetState();
				}
			}

			//Activate used item
			GameObject P_FindItem;
			if (P_FindItem = GameObject.Find("UTorch(Clone)"))
			{
				RemoveItem.transform.parent = gameObject.transform;
				UTorch P_Torch = P_FindItem.GetComponent<UTorch>();
				P_Torch.UT_ActivateTorch();
			}
			
		}
	}

	private void P_TryToOpenLockedDoor()
	{
		//If key is found, tell the door to open
		P_FindLockedDoor = GameObject.Find("LockedDoor");
		P_LockedDoor = P_FindLockedDoor.GetComponent<LockedDoor>();
		bool P_KeyFound = false;
		//Keep track at which index the key resides in order to remove it
		int P_ItemIndex = 0;


		for(int i =0;i<P_Inventory.IN_ItemCount();i++)
		{
			if(P_Inventory.IN_GetItemAtIndex(i).IT_GetName()=="Key")
			{
				P_ItemIndex = i;
				P_KeyFound = true;
				break;
			}
		}

		if(P_KeyFound==true)
		{

			P_LockedDoor.LD_OpenSesame();
			P_Inventory.IN_RemoveItemFromInventory(P_Inventory.IN_GetItemAtIndex(P_ItemIndex).IT_GetName());
			P_DoorOpened = true;
		}
		//Unless the door is closed, do not show the player interaction with it.
		else if(!P_DoorOpened)
		{
			P_VGUI.V_EToInteractFalse();
			P_VGUI.V_NoKeyChange();
		}
	}


	public Vector2 P_GetPosition()
	{
		return new Vector2(transform.position.x, transform.position.y);
	}

}

