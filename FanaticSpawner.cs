﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanaticSpawner : MonoBehaviour {
	private float spawnTime = 0;
	private float spawnRate = 0.2f;
	public void Spawn ()
	{
		if (Time.time > spawnTime) {
			spawnTime = Time.time + 1 / spawnRate;

			GameObject spawnedUnit = Instantiate (Resources.Load ("Prefabs/Fanatic", typeof(GameObject))) as GameObject;
			spawnedUnit.transform.position = transform.position;
			spawnedUnit.transform.rotation = transform.rotation;
			spawnedUnit.SetActive (true);
		} else {
			return;
		}
	}
}