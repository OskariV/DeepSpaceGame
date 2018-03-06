using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class JunkerAI : MonoBehaviour
	{
		private Radar radar;
		private MissileLauncher missileLauncher;
		private GameObject playerShip;
		private GameObject variableForPrefab;

		public float enemyShipSpeed { get; set; }

		public float enemyHitPoints { get; set; }


		void Start ()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyHitPoints = 100f;
			this.enemyShipSpeed = 2f;
			this.radar = GetComponentInChildren<Radar> ();
			this.missileLauncher = GetComponentInChildren<MissileLauncher> ();
			Debug.Log (missileLauncher);
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
				bool targetInRange = radar.RadarPing ();

				if (targetInRange == false) {
					
					this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
					this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
				
				}
				if (targetInRange == true) {
					this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 180));
					this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
					missileLauncher.rocket ();

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
			if (this.enemyHitPoints < 100f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.08f;
			}
		}
	}
}