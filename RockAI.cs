using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAI : MonoBehaviour {

	public float enemyHitPoints { get; set; }
	void Start () {
		this.enemyHitPoints = 1000f;
	}

	void Update () {
		
	}
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
