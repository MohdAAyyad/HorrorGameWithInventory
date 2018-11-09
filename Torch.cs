using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

public Vector2 T_GetPosition()
	{
		return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
	}
}
