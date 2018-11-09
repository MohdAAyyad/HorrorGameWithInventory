using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLight : MonoBehaviour {

	private Light Li_light;
	private float Li_Timer;
	private bool L_Activated;

	// Use this for initialization
	void Start () {
		Li_light = gameObject.GetComponent<Light>();
		Li_light.enabled = true;
		Li_Timer = 0.8f;
		L_Activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		Li_Flicker();

	}

	private void Li_Flicker()
	{

		//Only flicker if the lever is not activated yet
		if (L_Activated==false)
		{
			//Debug.Log("Not activated");
			if (Li_light.enabled)
			{
				Li_Timer -= Time.deltaTime;
				if (Li_Timer <= 0.0)
				{
					Li_light.enabled = false;
					Li_Timer = 0.8f;
				}
			}

			if (!Li_light.enabled)
			{
				Li_Timer -= Time.deltaTime;
				if (Li_Timer <= 0.0)
				{
					Li_light.enabled = true;
					Li_Timer = 0.8f;
				}
			}
		}

		else
		{
			
			Li_light.enabled = false;
		}

	}

	public void L_ActivatedChange()
	{
		//Lever activated.
		//Method is called from within the lever class when the player activates it.
		L_Activated = !L_Activated;
		Debug.Log("Change lights");
	}

	public void L_Reset()
	{
		//Lever activated.
		//Method is called from within the lever class when the player activates it.
		L_Activated = false;
	}
}
