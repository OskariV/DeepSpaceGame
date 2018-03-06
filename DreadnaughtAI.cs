using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class DreadnaughtAI : MonoBehaviour
	{
		private TargetRadar targetRadar;
		private DoomLaser doomLaser;
		private Laser laser1;
		private LaserLeft laser2;
		private MissileLauncher missileLauncher1;
		private MissileLeft missileLauncher2;
		private GameObject playerShip;
		private GameObject variableForPrefab;

		public float enemyShipSpeed { get; set; }

		public float enemyHitPoints { get; set; }


		void Start ()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyHitPoints = 500f;
			this.enemyShipSpeed = 2f;
			this.targetRadar = GetComponentInChildren<TargetRadar> ();
			this.laser1 = GetComponentInChildren<Laser> ();
			this.laser2 = GetComponentInChildren<LaserLeft> ();
			this.doomLaser = GetComponentInChildren<DoomLaser> ();
			this.missileLauncher1 = GetComponentInChildren<MissileLauncher> ();
			this.missileLauncher2 = GetComponentInChildren<MissileLeft> ();
		}

		void Update ()
		{
			if (this.playerShip != null) {
				this.RepairShip ();
				Vector3 targetPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
				Vector3 selfPos = Camera.main.WorldToScreenPoint (this.transform.position);
				selfPos.x = selfPos.x - targetPos.x;
				selfPos.y = selfPos.y - targetPos.y;
				float angle = Mathf.Atan2 (selfPos.y, selfPos.x) * Mathf.Rad2Deg;

				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
				this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);

				bool targetInSight = targetRadar.RadarPing ();
				if (targetInSight == true) {
					laser1.Shoot ();
					doomLaser.Shoot ();
					laser2.Shoot ();
					missileLauncher1.rocket ();
					missileLauncher2.rocket ();
				}

			}

		}

		public void TakeDamage (float x)
		{
			enemyHitPoints = enemyHitPoints - x;
			Debug.Log (enemyHitPoints);
			if (enemyHitPoints < 0) {
				Destroy (this.gameObject);
			}
		}
		private void RepairShip ()
		{
			if (this.enemyHitPoints < 500f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.01f;
			}
		}
	}
}