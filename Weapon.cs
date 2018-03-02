using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	private float fireRateLaser = 5f;
	private float fireRateRocket = 1f;
	private float fireSpeed = 1000f;
	private float rocketSpeed = 300f;
	private float fireTime = 0;


	void Update ()
	{


		if (fireRateLaser == 0 || fireRateRocket == 0) {
			Debug.LogError ("Cant Shoot Fire rate 0");
		} else {
			if (Input.GetMouseButton (0) && Time.time > fireTime) {
				fireTime = Time.time + 1 / fireRateLaser;
				Shoot ();
			}
			if (Input.GetMouseButton (1) && Time.time > fireTime) {
				fireTime = Time.time + 1 / fireRateRocket;
				rocket ();
			}
		}
	}

	void Shoot ()
	{

		GameObject bullet = Instantiate (Resources.Load ("Prefabs/blastLaser 1", typeof(GameObject))) as GameObject;
		bullet.transform.position = transform.position + transform.up * 1f;
		bullet.transform.rotation = transform.rotation;
		bullet.SetActive (true);
		bullet.GetComponent<Rigidbody2D> ().AddForce (transform.up * fireSpeed);
		Destroy (bullet, 3.0f);

	}

	void rocket ()
	{
		GameObject rocket = Instantiate (Resources.Load ("Prefabs/rocketPic 1", typeof(GameObject))) as GameObject;
		rocket.transform.position = transform.position + transform.up * 1f;
		rocket.transform.rotation = transform.rotation;
		rocket.SetActive (true);
		rocket.GetComponent<Rigidbody2D> ().AddForce (transform.up * rocketSpeed);
		Destroy (rocket, 3.0f);
	}
}
