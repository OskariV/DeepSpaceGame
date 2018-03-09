using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColl : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll)
	{		

		GameObject explosion = Instantiate (Resources.Load ("Prefabs/AsteroidExplosion", typeof(GameObject))) as GameObject;
		explosion.transform.position = transform.position;
		Destroy (explosion, 0.5f);
		Destroy (coll.gameObject);
	}
}
