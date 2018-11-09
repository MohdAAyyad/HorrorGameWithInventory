using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoAway : MonoBehaviour {

	private GameObject EGA_FindEnemy;
	private Enemy EGA_Enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void EGA_EnemyIsParent()
	{
		//Once the enemy spawns, become its child. The reason for this is we want this object to be destroyed after the player passes
		//So we destroy it wth the enemy
		if(EGA_FindEnemy= GameObject.Find("Enemy(Clone)"))
		{
			EGA_Enemy = EGA_FindEnemy.GetComponent<Enemy>();
			gameObject.transform.parent = EGA_FindEnemy.transform;
		}
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		//Tell the enemy to go away as the player has run away from him
		if (EGA_FindEnemy = GameObject.Find("Enemy(Clone)"))
		{
			if (col.gameObject.tag.Equals("Player"))
			{
				//Depending on which EnemyGoAway object the player comes across, the enemy moves away in a certain direction
				if (gameObject.tag.Equals("EnemyGoAway1"))
					{
					EGA_EnemyIsParent();
					EGA_Enemy.E_MoveAwayCheckChange(3.0f);
					}
				else if (gameObject.tag.Equals("EnemyGoAway2"))
					{
					EGA_EnemyIsParent();
					EGA_Enemy.E_MoveAwayCheckChange(-3.0f);
					}
			}
		}
		
	}
}
