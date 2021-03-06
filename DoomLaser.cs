﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomLaser : MonoBehaviour 
	{
		// Sets firerate.
		private float fireRateLaser = 0.5f;
		private float fireSpeed = 1000f;
		private float fireTime = 0;

		public void Shoot ()
		{
			// If enough time has passed creates doomlaser object and destroys it if it travels too long without colliding with an object.
			if (Time.time > fireTime) {
				fireTime = Time.time + 1 / fireRateLaser;
				GameObject bullet = Instantiate (Resources.Load ("Prefabs/IsoLaser", typeof(GameObject))) as GameObject;
				bullet.transform.position = transform.position + transform.up * 1f;
				bullet.transform.rotation = transform.rotation;
				bullet.SetActive (true);
				bullet.GetComponent<Rigidbody2D> ().AddForce (transform.up * fireSpeed);
				Destroy (bullet, 3.0f);
			} else {
				return;
			}
		}

	}
