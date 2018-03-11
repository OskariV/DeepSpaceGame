using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Test for projectile destruction

public class ShotDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Shot") {
			Destroy (other.gameObject);
		} 

	}

}
