using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierSubSpawner : MonoBehaviour {
	private float spawnTime = 0;
	private float spawnRate = 0.10f;
	public void Spawn ()
	{
		if (Time.time > spawnTime) {
			spawnTime = Time.time + 1 / spawnRate;

			GameObject spawnedUnit = Instantiate (Resources.Load ("Prefabs/Carrier subunit", typeof(GameObject))) as GameObject;
			spawnedUnit.transform.position = transform.position;
			spawnedUnit.transform.rotation = transform.rotation;
			spawnedUnit.SetActive (true);
		} else {
			return;
		}
	}
}
