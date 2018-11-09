using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromToBeDetected : MonoBehaviour {

	private SpriteRenderer PTD_SprtieRenderer;
	private float FadeDuration;
	private bool PTD_DetectedCheck;

	// Use this for initialization
	void Start () {

		PTD_SprtieRenderer = gameObject.GetComponent<SpriteRenderer>();

		gameObject.GetComponent<SpriteRenderer>().color = new Color(PTD_SprtieRenderer.color.r, PTD_SprtieRenderer.color.g, PTD_SprtieRenderer.color.b, 0.0f);
		FadeDuration = 1.5f;

		PTD_DetectedCheck = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(PTD_DetectedCheck)
		{
			PTD_Detected();
		}
		else
		{
			PTD_UnDetected();
		}
	}

	private void PTD_Detected()
	{

		float PTD_Alpha = 0;
		while(FadeDuration>0)
		{
			FadeDuration -= Time.deltaTime;
			PTD_SprtieRenderer.color = new Color(PTD_SprtieRenderer.color.r, PTD_SprtieRenderer.color.g, PTD_SprtieRenderer.color.b, PTD_Alpha += Time.deltaTime);
		}
		FadeDuration = 1.5f;
	}

	private void PTD_UnDetected()
	{
		float PTD_Alpha = 1;
		while (FadeDuration > 0)
		{
			FadeDuration -= Time.deltaTime;
			PTD_SprtieRenderer.color = new Color(PTD_SprtieRenderer.color.r, PTD_SprtieRenderer.color.g, PTD_SprtieRenderer.color.b, PTD_Alpha -= Time.deltaTime);
		}
		FadeDuration = 1.5f;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("DetectPlatforms"))
		{
			Debug.Log("Detected");
			PTD_DetectedCheck = true;
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("DetectPlatforms"))
		{
			PTD_DetectedCheck = false;
		}
	}

	public bool PTD_AreWeDetected()
	{
		return PTD_DetectedCheck;
	}
}
