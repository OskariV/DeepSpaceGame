using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public float fireRate = 0;
	public float fireSpeed = 0;
	public float rocketSpeed = 0;
	public float rocketRate = 0;
	public float Dmg = 10;
	public LayerMask dontShoot;
	public Transform bulletSpawn;

	private Vector3 mousePos;
	private float fireTime = 0;
	private Transform fire;

	void Start ()
	{
		fire = transform.Find ("Fire");
		if (fire == null) {
			Debug.LogError ("Cant fire");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.mousePos = Input.mousePosition;
		mousePos.z = 0.0f;


		if (fireRate == 0) {
			Debug.LogError ("Cant Shoot Fire rate 0");
		} else {
			if (Input.GetMouseButton (0) && Time.time > fireTime) {
				fireTime = Time.time + 1 / fireRate;
				Shoot ();
			}
			if (Input.GetMouseButton (1) && Time.time > fireTime) {
				fireTime = Time.time + 1 / fireRate;
				rocket ();
			}
		}
	}

	void Shoot ()
	{

		GameObject bullet = Instantiate (Resources.Load ("Prefabs/blastLaser 1", typeof(GameObject))) as GameObject;
		Debug.Log ("testi" + bullet.ToString ());
		bullet.transform.position = transform.position + transform.up * 1f;
		bullet.transform.rotation = transform.rotation;
		bullet.SetActive (true);
		bullet.GetComponent<Rigidbody2D> ().AddForce (transform.up * fireSpeed);
		Destroy (bullet, 3.0f);

	}

	void rocket ()
	{
		GameObject rocket = Instantiate (Resources.Load ("Prefabs/rocketPic 1", typeof(GameObject))) as GameObject;
		Debug.Log ("rocketestSpaceXshiet" + rocket.ToString ());
		rocket.transform.position = transform.position + transform.up * 1f;
		rocket.transform.rotation = transform.rotation;
		rocket.SetActive (true);
		rocket.GetComponent<Rigidbody2D> ().AddForce (transform.up * rocketSpeed);
		Destroy (rocket, 3.0f);
	}
}
