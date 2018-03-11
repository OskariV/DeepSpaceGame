using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour
{
	void Start ()
	{
	}

	private bool enemyInRange = false;

	/// <summary>
	/// Checks if enemy is in range.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		if (!other.tag.Contains ("Enemy") && !other.tag.Contains ("Shot") && !other.tag.Contains ("Radar")) {
			this.enemyInRange = true;
		}
	}

	/// <summary>
	/// Checks if enemy is not in range.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D (Collider2D other)
	{
		if (!other.tag.Contains ("Enemy") && !other.tag.Contains ("Shot") && !other.tag.Contains ("Radar")) {
			this.enemyInRange = false;
		}
	}

	//void OnTriggerStay2D(Collider2D other)
	//{
	//	if (!other.name.Equals (enemyShip)) {
	//		this.enemyInRange = true;
	//	}
	//}
	/// <summary>
	/// Pings the radar.
	/// </summary>
	/// <returns><c>true</c>, if ping was radared, <c>false</c> otherwise.</returns>
	public bool RadarPing ()
	{
		return this.enemyInRange;
	}
}
