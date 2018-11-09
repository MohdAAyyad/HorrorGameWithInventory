using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

	private Animator LD_Animator;

	// Use this for initialization
	void Start () {

		LD_Animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//Check if door is opened or not. If it is, change scene
		if (LD_Animator.GetCurrentAnimatorStateInfo(0).IsName("OpenedDoor"))
		{
			Debug.Log("Animation Has finished, door is opened successfully");
		}
	}

	public void LD_OpenSesame()
	{
		//Open the door
		LD_Animator.SetBool("LD_Open", true);


		
	}
}
