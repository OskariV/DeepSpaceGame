using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour
{
	void Start() {
	}
	private bool enemyInRange = false;
	//private GameObject enemyShip = GameObject.Find ("TestEnemy");

	void OnTriggerEnter2D(Collider2D other) {
		if (!other.name.Equals("TestEnemy")) {
			this.enemyInRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (!other.name.Equals ("TestEnemy")) {
			this.enemyInRange = false;
		}
	}

	//void OnTriggerStay2D(Collider2D other)
	//{
	//	if (!other.name.Equals (enemyShip)) {
	//		this.enemyInRange = true;
	//	}
	//}
	public bool RadarPing()
	{
		return this.enemyInRange;
	}	
}