using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	private bool playerColl = false;

	public void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject) {
			this.playerColl = true;
			//Debug.Log ("entered coll with " + collision.gameObject.tag);
		}
		//collision.gameObject.transform.Translate (1f, 0, 0);
		//transform.Translate (-1f, 0, 0);
	}
	public void OnCollisionExit2D (Collision2D collision)
	{
		if (collision.gameObject) {
			//Debug.Log ("exited coll with " + collision.gameObject.tag);
			this.playerColl = false;
		}
	}

	/// <summary>
	/// Gets the player coll.
	/// </summary>
	/// <returns><c>true</c>, if player coll was gotten, <c>false</c> otherwise.</returns>
	public bool GetPlayerColl()
	{
		return this.playerColl;
	}
}
