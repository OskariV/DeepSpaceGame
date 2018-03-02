using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	
	public class UnitPlayer : MonoBehaviour
	{
		private GameObject playerShip;

		public int playerHitPoints { get; set; }

		public float playerShipSpeed { get; set; }
		//public GameObject shot;
		//public Transform shotSpawn;
		//public float fireRate;
		//private float nextFire;

		public void TakeDamage (int amount)
		{
			playerHitPoints = playerHitPoints - amount;
			Debug.Log (playerHitPoints);
			if (playerHitPoints < 0) {
				Destroy (this.gameObject);
			}
		}

		void Start ()
		{
			this.playerShip = GameObject.Find ("PlayerShip");
			this.playerHitPoints = 100;
			this.playerShipSpeed = 8f;
		}

		void Update ()
		{
			if (this.playerShip != null) {
				
				//if (Input.GetButton("Fire1") && Time.time > nextFire)
				//{
				//nextFire = Time.time + fireRate;
				//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				//}

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
		public void OnCollisionEnter2D (Collision2D collision)
		{
			if (collision.gameObject) {
				TakeDamage (10);

			}

		}

	}
}

