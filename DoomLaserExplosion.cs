using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomLaserExplosion : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (!other.tag.Contains ("Radar")) {
			other.SendMessage ("TakeDamage", 99f);
			GameObject explosion = Instantiate (Resources.Load ("Prefabs/Explosion", typeof(GameObject))) as GameObject;
			explosion.transform.position = transform.position;
			Destroy (explosion, 0.5f);
			Destroy (this.gameObject);
		}
	}
}
