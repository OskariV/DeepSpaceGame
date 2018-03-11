using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAI : MonoBehaviour {
	
	// Sets health for a rock object.
	public float enemyHitPoints { get; set; }
	void Start () {
		this.enemyHitPoints = 1000f;
	}

	void Update () {
		
	}
	
	// Makes rock object take damage and destroys it when health is depleted.
	void OnCollisionStayEnter2D (Collision2D other)
	{
		TakeDamage (1);
	}
	public void TakeDamage (float x)
	{
		enemyHitPoints = enemyHitPoints - x;
		Debug.Log (enemyHitPoints);
		if (enemyHitPoints < 0) {
			Destroy (this.gameObject);
		}
	}
}
