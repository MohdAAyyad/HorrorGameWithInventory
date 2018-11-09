using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParchmentLight : MonoBehaviour {

	private Light Li_light;
	private float Li_Timer;
	private bool L_Activated;

	// Use this for initialization
	void Start()
	{
		Li_light = gameObject.GetComponent<Light>();
		Li_light.enabled = true;
		Li_Timer = 0.8f;
		L_Activated = false;
	}

	// Update is called once per frame
	void Update()
	{
		Li_Flicker();

	}

	private void Li_Flicker()
	{

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
}
