using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
public class MoonAI : MonoBehaviour 
{
		private Radar radar;
		private TargetRadar targetRadar;
		private DoomLaser doomLaser;
		private Laser laser1;
		private LaserLeft laser2;
		private CarrierSubSpawner carrierSubSpawner;
		private FanaticSpawner fanaticSpawner;
		private GameObject playerShip;
		private GameObject variableForPrefab;
		public float enemyShipSpeed { get; set; }
		public float enemyHitPoints { get; set; }

		//Sets health, speed, finds it's own radars and weapons and targets player.
		void Start()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.radar = GetComponentInChildren<Radar> ();
			this.targetRadar = GetComponentInChildren<TargetRadar> ();
			this.laser1 = GetComponentInChildren<Laser> ();
			this.laser2 = GetComponentInChildren<LaserLeft> ();
			this.carrierSubSpawner = GetComponentInChildren<CarrierSubSpawner> ();
			this.fanaticSpawner = GetComponentInChildren<FanaticSpawner> ();
			this.doomLaser = GetComponentInChildren<DoomLaser> ();
			this.enemyHitPoints = 1000f;
			this.enemyShipSpeed = 3f;
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
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
				// Moves towards player.
				this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
				bool outer = targetRadar.RadarPing ();
				bool inner = radar.RadarPing ();
				// Spawns units.
				fanaticSpawner.Spawn ();
				carrierSubSpawner.Spawn ();
				// If player is either too far or too close fires weapons towards player.
				if (outer == false) {
					doomLaser.Shoot ();
				}
				if (inner == true) {
					laser1.Shoot ();
					laser2.Shoot ();
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
		// Repairs ship if health is below full. Repairs faster when more damage is taken.
		private void RepairShip ()
		{
			if (this.enemyHitPoints < 1000f && this.enemyHitPoints > 500f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.02f;
			} else if (this.enemyHitPoints < 500f && this.enemyHitPoints > 100f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.04f;
			} else if (this.enemyHitPoints < 100f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.08f;
			}
		}
	}
}
