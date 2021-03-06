﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {
	// Sets firerate
	private float rocketSpeed = 300f;
	private float fireRateRocket = 1f;
	private float fireTime = 0;

	public void rocket ()
	{
		// If enough time has passed creates missile object and destroys it if it travels too long without colliding with an object.
		if (Time.time > fireTime) {
			fireTime = Time.time + 1 / fireRateRocket;
			GameObject rocket = Instantiate (Resources.Load ("Prefabs/rocketPic 1", typeof(GameObject))) as GameObject;
			rocket.transform.position = transform.position + transform.up * 1f;
			rocket.transform.rotation = transform.rotation;
			rocket.SetActive (true);
			rocket.GetComponent<Rigidbody2D> ().AddForce (transform.up * rocketSpeed);
			Destroy (rocket, 3.0f);
		} else {
			return;
		}
	}
}
