using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Units;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		public UnitPlayer player; 
		public GameObject enemy;
		private Text textHp;
		private Vector3 test;

		// these values are used to prevent the if-loops executing more than once.
		private bool winCond = false;
		private bool loseCond = false;

		void Start ()
		{
			this.player = GameObject.Find("PlayerShip").GetComponent<UnitPlayer>();
			this.textHp = GameObject.Find ("TextHp").GetComponent<Text> ();
			this.test = new Vector3 (5f, 3f, 0);
			//enemy = Instantiate (enemy, test, Quaternion.identity) as GameObject;
			//enemy = Instantiate (enemy, new Vector3(4f, 4f, 0), Quaternion.identity) as GameObject;
		}

		void Update ()
		{
			if (GameObject.Find ("PlayerShip") != null) {
				this.textHp.text = "Player hitpoints: " + this.player.GetPlayerHitPoints();
			}
			if (GameObject.Find ("PlayerShip") == null) {
				this.textHp.text = "Player hitpoints: " + 0;
			}
			/*when this code cant find a gameobject with the tag "Enemy",
			it returns to the assigned scene (currently set at 0).*/
			if ((GameObject.FindWithTag ("Enemy") == null) && (winCond == false)) {
				Debug.Log ("inside if enemy loop");
				this.winCond = true;
				SceneManager.LoadScene (0); // 0 is main menu.
			}

			/*when this code cant find a gameobject with the tag "Player",
			it returns to the assigned scene (currently set at 1).*/
			if ((GameObject.FindWithTag ("Player") == null) && (loseCond == false)) {
				Debug.Log ("inside if player loop");
				this.loseCond = true;
				SceneManager.LoadScene (1); // 1 is level select.
			}
		}
	}
}
