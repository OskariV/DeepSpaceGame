/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;

public class Destruction : MonoBehaviour {

	private PlayerCollision playerColl;
	private UnitPlayer playerShip;

	void Start () {
		this.playerColl = GameObject.Find("PlayerShip").GetComponent<PlayerCollision>();
		this.playerShip = GameObject.Find("PlayerShip").GetComponent<UnitPlayer>();
	}

	void Update () {
		if (this.playerColl.GetPlayerColl () && this.playerShip != null) {
			this.playerShip.TakeDamage (1);
			if (this.playerShip.playerHitPoints == 0) {
				DestroyObject(GameObject.Find("PlayerShip"));
			}
		}
	}

	private void DestroyObject(GameObject g){
		if(g != null){
			Destroy (g);
		}
	}
}
*/