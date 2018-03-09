using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Units;

namespace Level2
{

	public class GameControllerL2 : MonoBehaviour
	{
		public UnitPlayer player; 
		public GameObject enemy;
		private Text textHp;
		private Vector3 test;
		public FanaticSpawner spawner;
		public FanaticSpawner spawner2;

		// these values are used to prevent the if-loops executing more than once.
		private bool winCond = false;
		private bool loseCond = false;

		void Start ()
		{
			this.player = GameObject.Find("PlayerShip").GetComponent<UnitPlayer>();
			this.textHp = GameObject.Find ("TextHp").GetComponent<Text> ();
			this.test = new Vector3 (5f, 3f, 0);
		}

		void Update ()
		{
			// Displays playerHitPoints when the player's gameobject is not null.
			if (GameObject.Find ("PlayerShip") != null) {
				TextColor ();
				this.textHp.text = this.player.GetPlayerHitPoints ().ToString("0");
				this.spawner.Spawn ();
				this.spawner2.Spawn ();
			}
			// Same as above but defaults to "0" when the gameobject is destroyed.
			if (GameObject.Find ("PlayerShip") == null) {
				TextColor ();
				this.textHp.text = "0";
			}
			/*when this code cant find a gameobject with the tag "Enemy",
			it returns to the assigned scene (currently set at 0).*/
			if ((GameObject.FindWithTag ("Finish") == null) && (winCond == false)) {
				Debug.Log ("inside if enemy loop");
				this.winCond = true;
				SceneManager.LoadScene (4); // 0 is main menu.
			}

			/*when this code cant find a gameobject with the tag "Player",
			it returns to the assigned scene (currently set at 1).*/
			if ((GameObject.FindWithTag ("Player") == null) && (loseCond == false)) {
				Debug.Log ("inside if player loop");
				this.loseCond = true;
				SceneManager.LoadScene (5); // 1 is level select.
			}
		}
		/// <summary>
		/// Changes textHp's color depending on playerHitPoints.
		/// +75 green
		/// +50 < 75 yellow
		/// < 50 red.
		/// </summary>
		private void TextColor()
		{
			if (this.player.GetPlayerHitPoints () >= 75f) {
				this.textHp.color = Color.green;
			} else if ((this.player.GetPlayerHitPoints () >= 50f) && (this.player.GetPlayerHitPoints () < 75f)) {
				this.textHp.color = Color.yellow;
			} else {
				this.textHp.color = Color.red;
			}
		}
	}
}

