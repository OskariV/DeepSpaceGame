using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
	public Vector3 spawnValue;
	public int meteorAmount;
	public float spawnWait;
	public float startWait;

	void Start ()
	{
		//Calls Spawn Corountine
		StartCoroutine (Spawn ());
	}

	// Creates the corountine
	IEnumerator Spawn ()
	{
		//sets how amount of time before asteroids start to spawn, yield command stops and defines when the corountine resumes
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < meteorAmount; i++) {
			// Loads Asteroid prefab, now it doesn't need to be pre set in unity
			GameObject Asteroid = Resources.Load ("Prefabs/Asteroid2 1", typeof(GameObject)) as GameObject;
			//Gives random value from max-min range of spawnvalues
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y);
			// for the vector3 instantiate
			Quaternion spawnRotation = new Quaternion ();
			//instantiate makes a clone from the original and returns the clone
			Instantiate (Asteroid, spawnPosition, spawnRotation);
			//sets how frequently asteroids spawn, waits spawnWait variables amounts before for loop runs again.
			yield return new WaitForSeconds (spawnWait);
		}
	}
}