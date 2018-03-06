using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	
	public class UnitPlayer : MonoBehaviour
	{
		private GameObject playerShip;
		private float playerHitPoints;
		private float playerShipSpeed;

		/// <summary>
		/// Sets the player hit points.
		/// </summary>
		/// <param name="value">Value.</param>
		public void SetPlayerHitPoints(float value)
		{
			this.playerHitPoints = value;
			// hp palkki juttu
		}
		/// <summary>
		/// Gets the player hit points.
		/// </summary>
		/// <returns>The player hit points.</returns>
		public float GetPlayerHitPoints()
		{
			return this.playerHitPoints;
		}
		/// <summary>
		/// Takes the damage.
		/// </summary>
		/// <param name="amount">Amount.</param>
		public void TakeDamage (float amount)
		{
			SetPlayerHitPoints(GetPlayerHitPoints() - amount);
			if (GetPlayerHitPoints() <= 0) {
				Destroy (this.gameObject);
			}
		}
		private void RepairShip ()
		{
			if (this.playerHitPoints < 100f) {
				this.playerHitPoints = this.playerHitPoints + 0.08f;
			}
		}
		//calls the TakeDamage method when the player's gameobject touches something.
		public void OnCollisionEnter2D (Collision2D collision)
		{
			if (collision.gameObject) {
				TakeDamage (10);
			}
		}

		void Start ()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			SetPlayerHitPoints(100f);
			this.playerShipSpeed = 8f;
		}

		void Update ()
		{
			// checks if the playership GameObject still exists.
			if (this.playerShip != null) {

				RepairShip ();
				
				//Playership rotation (ship points towards mouse position).
				Vector3 mousePos = Input.mousePosition;
				mousePos.z = 0f;

				Vector3 objectPos = Camera.main.WorldToScreenPoint (playerShip.transform.position);
				mousePos.x = mousePos.x - objectPos.x;
				mousePos.y = mousePos.y - objectPos.y;

				float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
				playerShip.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));

				//Playership movement (WASD- or arrowkey movement).
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
}

