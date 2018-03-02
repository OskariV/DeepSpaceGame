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
		public int enemyHitPoints { get; set; }


		void Start()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyHitPoints = 10;
			this.enemyShipSpeed = 3f;
		}

		void Update ()
		{
			if (this.playerShip != null) {
				Vector3 targetPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
				Vector3 selfPos = Camera.main.WorldToScreenPoint (this.transform.position);
				selfPos.x = selfPos.x - targetPos.x;
				selfPos.y = selfPos.y - targetPos.y;
				float angle = Mathf.Atan2 (selfPos.y, selfPos.x) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
				this.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
			}
		}
		public void TakeDamage (int x)
		{
			Debug.Log ("damage");
			enemyHitPoints = enemyHitPoints - x;
			Debug.Log (enemyHitPoints);
			if (enemyHitPoints < 0) {
				Destroy (this.gameObject);
			}
		}

	}
}


