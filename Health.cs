using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	public class Health : MonoBehaviour
	{
		private int hitPoints;
		void Start()
		{
			//this.gameObject.
		}
		public void TakeDamage (int x)
		{
			Debug.Log ("damage");
			hitPoints = hitPoints - x;
			Debug.Log (hitPoints);
			if (hitPoints < 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
//if (other.GetComponent <Health>()) {
//		other.GetComponent <Health>().TakeDamage (1);
//}