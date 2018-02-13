using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class UnitEnemy : UnitBase
	{
		private GameObject enemyShip;
		private GameObject playerShip;
		private Radar radar;

		private float enemyShipSpeed { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="Units.UnitEnemy"/> class.
		/// </summary>
		/// <param name="unitName">Unit name.</param>
		/// <param name="hitPoints">Hit points.</param>

		public UnitEnemy (string unitName, int hitPoints) : base (unitName, hitPoints)
		{
			this.enemyShip = GameObject.Find ("TestEnemy");
			this.playerShip = GameObject.Find ("PlayerShip");
			this.radar = GameObject.Find ("Radar").GetComponent<Radar>();
			//this.radar = new Radar();
			this.enemyShipSpeed = 3f;
		}
		/// <summary>
		/// Move this instance. Aligns the enemy instance towards player instance
		/// </summary>
		public void Move ()
		{
			Vector3 targetPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
			Vector3 selfPos = Camera.main.WorldToScreenPoint (enemyShip.transform.position);
			selfPos.x = selfPos.x - targetPos.x;
			selfPos.y = selfPos.y - targetPos.y;
			float angle = Mathf.Atan2 (selfPos.y, selfPos.x) * Mathf.Rad2Deg;
			bool iff = radar.RadarPing ();
			if ( iff == false) {
				enemyShip.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 270));
				this.enemyShip.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
			}
			if ( iff == true) {
				enemyShip.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 180));
				this.enemyShip.transform.Translate (0, 0.01f * enemyShipSpeed, 0, Space.Self);
			}
		}
	}
}

