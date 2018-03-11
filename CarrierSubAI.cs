using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class CarrierSubAI : MonoBehaviour
	{
		private Radar radar;
		private Laser laser;
		private GameObject playerShip;
		private GameObject variableForPrefab;

		public float enemyShipSpeed { get; set; }

		public float enemyHitPoints { get; set; }

		//Sets health, speed, finds it's own radars and weapons and targets player.
		void Start ()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyHitPoints = 5f;
			this.enemyShipSpeed = 6f;
			this.radar = GameObject.Find ("RadarCarrierSub").GetComponent<Radar> ();
			this.laser = GetComponentInChildren<Laser> ();
		}

		void Update ()
		{
			if (this.playerShip != null) {
				//aims towards player.
				Vector3 targetPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
				Vector3 selfPos = Camera.main.WorldToScreenPoint (this.transform.position);
				selfPos.x = selfPos.x - targetPos.x;
				selfPos.y = selfPos.y - targetPos.y;
				float angle = Mathf.Atan2 (selfPos.y, selfPos.x) * Mathf.Rad2Deg;
				bool targetInRange = radar.RadarPing ();
				//Moves towards player
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
				this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
				// If player is in TargetRadar range fires lasers
				if (targetInRange == false) {
				}
				if (targetInRange == true) {
					laser.Shoot ();

				}
			}

		}
		// Makes ship take damage and destroys it when health is depleted.
		public void TakeDamage (float x)
		{
			enemyHitPoints = enemyHitPoints - x;
			Debug.Log (enemyHitPoints);
			if (enemyHitPoints < 0) {
				Destroy (this.gameObject);
			}
		}

	}
}
