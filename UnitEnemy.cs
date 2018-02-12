using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class UnitEnemy : UnitBase
	{
		private GameObject enemyShip;
		private GameObject playerShip;

		private float enemyShipSpeed { get; set; }
		
		public UnitEnemy (string unitName, int hitPoints) : base (unitName, hitPoints)
		{
			this.enemyShip = GameObject.Find ("TestEnemy");
			this.playerShip = GameObject.Find ("PlayerShip");
			this.enemyShipSpeed = 3f;
		}
		public void Move ()
		{
			Vector3 targetPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
			Vector3 selfPos = Camera.main.WorldToScreenPoint (enemyShip.transform.position);
			selfPos.x = selfPos.x - targetPos.x;
			selfPos.y = selfPos.y - targetPos.y;
			float angle = Mathf.Atan2 (selfPos.y, selfPos.x) * Mathf.Rad2Deg;
			enemyShip.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
			this.enemyShip.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
		}
	}
}

