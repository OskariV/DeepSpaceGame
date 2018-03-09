using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	public void OnCollisionEnter2D (Collision2D collision)
	{
		//Debug.Log ("test 123  " + collision.gameObject);
		//collision.gameObject.transform.Translate (1f, 0, 0);
		//transform.Translate (-1f, 0, 0);
	}
}
