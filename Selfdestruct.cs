using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class Selfdestruct : MonoBehaviour
	{
		// Used by laser object to find collision with other objects.
		void OnTriggerEnter2D (Collider2D other)
		{
			// If interacts with anything other than a radar collider.
			if (!other.tag.Contains ("Radar")) {
				// Uses Unitys SendMessage function to use other colliders Takedamage method to deal damage.
				other.SendMessage ("TakeDamage", 5f);
				// Creates an explosion sprite.
				GameObject explosion = Instantiate (Resources.Load ("Prefabs/LaserImpact", typeof(GameObject))) as GameObject;
				explosion.transform.position = transform.position;
				// Destroys the explosion sprite and itself.
				Destroy (explosion, 0.5f);
				Destroy (this.gameObject);
			}

		}

	}
}
