using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTorch : MonoBehaviour {

	private float UT_timer;
	private bool UT_Activated = false;

	void Start () {
		//Timer to see how long the torch will stay lit
		UT_timer = 20.0f;

	}
	
		void Update () {

		if (UT_Activated)
		{
			if (UT_timer < 0.0f)
			{
				Destroy(gameObject);
			}
			else
			{
				UT_timer -= Time.deltaTime;
			}
			
		}
		
	}

	public void UT_ActivateTorch()
	{
		UT_Activated = true;
	}
}
