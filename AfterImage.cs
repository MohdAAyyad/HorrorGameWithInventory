using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour {

	private GameObject AI_FindPlayer;
	private float AI_FadeoutTimer;
	//Fadeout the spirte color
	private Color AI_Color_Fadeout;
	//Keep track of the original color
	private Color AI_Color_Original;

	private float cooler;

	// Use this for initialization
	void Start () {
		//Find the player
		AI_FindPlayer = GameObject.Find("Player_NoSpotLight");
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		AI_FadeoutTimer = 7.0f;
		AI_Color_Original = gameObject.GetComponent<SpriteRenderer>().color;
		AI_Color_Fadeout = gameObject.GetComponent<SpriteRenderer>().color;

		cooler = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Check if we are in the animation state ("Player_Run"). If we are, show the after images, if we're not remove the after images.
		//if(AI_FindPlayer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Run"))
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			
			gameObject.GetComponent<SpriteRenderer>().color = AI_Color_Original;
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			AI_Color_Fadeout = AI_Color_Original;
			Debug.Log("Player_NOOOO Run");
			while (AI_FadeoutTimer>0.0f)
			{
				AI_FadeoutTimer -= Time.deltaTime;
				cooler -= Time.deltaTime;
				
				if(cooler<=0.0f)
				{
					cooler = 0.0f;
				}
				gameObject.GetComponent<SpriteRenderer>().color = new Color(AI_Color_Original.r, AI_Color_Original.g, AI_Color_Original.b, cooler) ;
			}
			AI_FadeoutTimer = 7.0f;
			
			//gameObject.GetComponent<SpriteRenderer>().enabled = false;

			/*for (int i = 50; i > 0; i--)
			{
				gameObject.GetComponent<SpriteRenderer>().color = new Color(164.0f, 46.0f, 46.0f,Mathf.SmoothStep(50.0f,0.0f,50.0f));
			}*/
		}

	}

}
