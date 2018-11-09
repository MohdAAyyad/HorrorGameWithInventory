using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour {

	//Torch-to-light-up tracker
	private int PC_WhichTorch;
	//Generic GameObject variable to get any needed game object
	private GameObject PC_GameObjects;
	//Used to reset the levers
	private LeverRed PC_LeverRed;
	private LeverGreen PC_LeverGreen;
	private LeverBlue PC_LeverBlue;
	//Used to reset the flame
	private Flame PC_Flame;
	//Where should the flame be instatiated?
	private Vector2 PC_LightUpPostion;
	//Get the toches
	private Torch PC_Torch;
	//For prefabs
	public GameObject PC_RedFlame;
	public GameObject PC_GreenFlame;
	public GameObject PC_BlueFlame;
	public GameObject PC_Key;
	//Store the answers
	private int[] PC_Answers;
	//Used for resetting the lights.
	private ItemLight PC_ItemLight;

	

	// Use this for initialization
	void Start () {
		PC_WhichTorch = 1;

		PC_Answers = new int[3];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void PC_LightRed()
	{
		//Check which torch to ligt up.
		//Light it up with the color provided from the levers.
		//Store the answer
		//Increment torch position

		if (PC_WhichTorch==1)
		{
			if (PC_GameObjects = GameObject.Find("Torch"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y+1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_RedFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch++;
				PC_Answers[0] = 1;
			}
		}
		
		else if(PC_WhichTorch==2)
		{
			if (PC_GameObjects = GameObject.Find("Torch 2"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_RedFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch++;
				PC_Answers[1] = 1;
			}

		}
		else if(PC_WhichTorch==3)
		{

			if (PC_GameObjects = GameObject.Find("Torch 3"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_RedFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch=1;
				PC_Answers[2] = 1;

				//After lighting up the third torch, check answers

				PC_CheckAnswers();
			}

		}
	}

	private void PC_LightGreen()
	{
		//Check which torch to ligt up.
		//Light it up with the color provided from the levers.
		//Store the answer
		//Increment torch position

		if (PC_WhichTorch == 1)
		{
			if (PC_GameObjects = GameObject.Find("Torch"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_GreenFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch++;
				PC_Answers[0] = 2;
			}
		}

		else if (PC_WhichTorch == 2)
		{
			if (PC_GameObjects = GameObject.Find("Torch 2"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_GreenFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch++;
				PC_Answers[1] = 2;
			}

		}
		else if (PC_WhichTorch == 3)
		{

			if (PC_GameObjects = GameObject.Find("Torch 3"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_GreenFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch = 1;
				PC_Answers[2] = 2;

				PC_CheckAnswers();
			}

		}
	}

	private void PC_LightBlue()
	{
		//Check which torch to ligt up.
		//Light it up with the color provided from the levers.
		//Store the answer
		//Increment torch position

		if (PC_WhichTorch == 1)
		{
			if (PC_GameObjects = GameObject.Find("Torch"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_BlueFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch++;
				PC_Answers[0] = 3;
			}
		}

		else if (PC_WhichTorch == 2)
		{
			if (PC_GameObjects = GameObject.Find("Torch 2"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_BlueFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch++;
				PC_Answers[1] = 3;
			}

		}
		else if (PC_WhichTorch == 3)
		{

			if (PC_GameObjects = GameObject.Find("Torch 3"))
			{
				PC_Torch = PC_GameObjects.GetComponent<Torch>();
				PC_LightUpPostion = new Vector2(PC_Torch.T_GetPosition().x, PC_Torch.T_GetPosition().y + 1.0f);
				GameObject G_NewEnemy = (GameObject)Instantiate(PC_BlueFlame, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
				PC_WhichTorch = 1;
				PC_Answers[2] = 3;

				PC_CheckAnswers();
			}

		}
	}

	private void PC_CheckAnswers()
	{
		//1=red
		//2=green
		//3=blue

		if(PC_Answers[0]==2 && PC_Answers[1]==1 && PC_Answers[2]==3)
		{
			//Instantiate key
			PC_LightUpPostion = new Vector2(PC_LightUpPostion.x + 4.0f, PC_LightUpPostion.y - 2.5f);
			GameObject G_NewEnemy = (GameObject)Instantiate(PC_Key, PC_LightUpPostion, Quaternion.Euler(0f, 0f, 0f));
		}
		else
		{
			//Reset everything
			if(PC_GameObjects = GameObject.Find("PuzzleLeverRed"))
			{
				PC_LeverRed = PC_GameObjects.GetComponent<LeverRed>();
				PC_LeverRed.L_Reset();
			}

			if (PC_GameObjects = GameObject.Find("PuzzleLeverGreen"))
			{
				PC_LeverGreen = PC_GameObjects.GetComponent<LeverGreen>();
				PC_LeverGreen.L_Reset();
			}

			if (PC_GameObjects = GameObject.Find("PuzzleLeverBlue"))
			{
				PC_LeverBlue = PC_GameObjects.GetComponent<LeverBlue>();
				PC_LeverBlue.L_Reset();
			}
			if (PC_GameObjects = GameObject.Find("Red Flame(Clone)"))
			{
				PC_Flame = PC_GameObjects.GetComponent<Flame>();
				PC_Flame.F_DestorySelf();
			}
			if (PC_GameObjects = GameObject.Find("Green Flame(Clone)"))
			{
				PC_Flame = PC_GameObjects.GetComponent<Flame>();
				PC_Flame.F_DestorySelf();
			}
			if (PC_GameObjects = GameObject.Find("Blue Flame(Clone)"))
			{
				PC_Flame = PC_GameObjects.GetComponent<Flame>();
				PC_Flame.F_DestorySelf();
			}

			if (PC_GameObjects = GameObject.Find("Lever_Light_Red"))
			{
				PC_ItemLight = PC_GameObjects.GetComponent<ItemLight>();
				PC_ItemLight.L_ActivatedChange();
			}
			if (PC_GameObjects = GameObject.Find("Lever_Light_Green"))
			{
				PC_ItemLight = PC_GameObjects.GetComponent<ItemLight>();
				PC_ItemLight.L_ActivatedChange();
			}
			if (PC_GameObjects = GameObject.Find("Lever_Light_Blue"))
			{
				PC_ItemLight = PC_GameObjects.GetComponent<ItemLight>();
				PC_ItemLight.L_ActivatedChange();
			}
		}
	}
}
