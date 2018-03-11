using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class RaiderAI : MonoBehaviour
	{
		private Radar radar;
		private TargetRadar targetRadar;
		private Laser laser;
		private GameObject playerShip;
		private GameObject variableForPrefab;

		public float enemyShipSpeed { get; set; }

		public float enemyHitPoints { get; set; }

		//Sets health, speed, finds it's own radars and targets player.
		void Start ()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyHitPoints = 50f;
			this.enemyShipSpeed = 5f;
			this.radar = GetComponentInChildren<Radar> ();
			this.targetRadar = GetComponentInChildren<TargetRadar> ();
			this.laser = GetComponentInChildren<Laser> ();
		}

		void Update ()
		{
			//aims towards player.
			if (this.playerShip != null) {
				this.RepairShip ();
				Vector3 targetPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
				Vector3 selfPos = Camera.main.WorldToScreenPoint (this.transform.position);
				selfPos.x = selfPos.x - targetPos.x;
				selfPos.y = selfPos.y - targetPos.y;
				float angle = Mathf.Atan2 (selfPos.y, selfPos.x) * Mathf.Rad2Deg;
				bool targetInRange = radar.RadarPing ();
				bool targetInSight = targetRadar.RadarPing ();

				//moves towards player if not in radar range
				if (targetInRange == false) {
					this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
					this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
					//shoots when player is in TargetRadars range.
					if (targetInSight == true) {
						laser.Shoot ();
					}
				}
				// If player is in radar range moves away from player
				if (targetInRange == true) {
					this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));
					this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);


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
		// Repairs ship if health is below full.
		private void RepairShip ()
		{
			if (this.enemyHitPoints < 50f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.08f;
			}
		}
	}
}
