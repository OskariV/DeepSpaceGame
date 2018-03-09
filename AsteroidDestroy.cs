using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour {

	public int meteoriteHitPoints { get; set; }

	void OnCollisionEnter2D (Collision2D coll)
	{		

		GameObject explosion = Instantiate (Resources.Load ("Prefabs/AsteroidExplosion", typeof(GameObject))) as GameObject;
		explosion.transform.position = transform.position;
		Destroy (explosion, 0.5f);
		Destroy (this.gameObject);
		Destroy (coll.gameObject);
	}
	void Start ()
	{
		this.meteoriteHitPoints = 25;
		Destroy (this.gameObject, 15.0f);
	}
	public void TakeDamage (int x)
	{
		meteoriteHitPoints = meteoriteHitPoints - x;
		Debug.Log (meteoriteHitPoints);
		if (meteoriteHitPoints < 0) {
			Destroy (this.gameObject);
		}
	}
}