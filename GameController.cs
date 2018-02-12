using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using Units;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		private UnitPlayer player;

		void Start ()
		{
			this.player = new UnitPlayer ("Player", 3);

			//testing
			Debug.Log (this.player.GetUnitName ());
			Debug.Log (this.player.GetHitPoints ());
			this.player.SetHitPoints (5);
			Debug.Log (this.player.GetHitPoints ());
		}

		void Update ()
		{
			this.player.Move ();
		}
	}
}
