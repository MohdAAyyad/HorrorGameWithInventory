using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {

public void LightUp()
	{
		SendMessageUpwards("L_ActivatedChange");
	}
}
