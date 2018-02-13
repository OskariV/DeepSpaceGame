using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	
	public class UnitPlayer : UnitBase
	{
		private GameObject playerShip;

		private float playerShipSpeed { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Units.UnitPlayer"/> class.
		/// </summary>
		/// <param name="unitName">Unit name.</param>
		/// <param name="hitPoints">Hit points.</param>
		public UnitPlayer (string unitName, int hitPoints) : base (unitName, hitPoints)
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.playerShipSpeed = 6f;
		}

		/// <summary>
		/// Used to initiate movement for the UnitPlayer object.
		/// </summary>
		public void Move ()
		{
			//rotation
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 0f;

			Vector3 objectPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;

			float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			playerShip.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));

			//movement
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				this.playerShip.transform.Translate (-0.01f * playerShipSpeed, 0, 0);

			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				this.playerShip.transform.Translate (0.01f * playerShipSpeed, 0, 0);
			}
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
				this.playerShip.transform.Translate (0, 0.01f * playerShipSpeed, 0);
			}
			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
				this.playerShip.transform.Translate (0, -0.01f * playerShipSpeed, 0);

			}
		}
	}
}
