﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class UnitEnemy : MonoBehaviour
	{
		private GameObject playerShip;
		private GameObject variableForPrefab;
		public float enemyShipSpeed { get; set; }
		public float enemyHitPoints { get; set; }


		void Start()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyHitPoints = 10f;
			this.enemyShipSpeed = 9f;
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
			if (this.enemyHitPoints < 10f) {
				this.enemyHitPoints = this.enemyHitPoints + 0.08f;
			}
		}
	}
}


