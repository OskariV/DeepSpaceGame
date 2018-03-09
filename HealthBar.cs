using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Units;

public class HealthBar : MonoBehaviour {

	private UnitPlayer player;
	public Image content;

	//used to determine the speed at which the healthbar moves.
	private float lerpSpeed = 8f;
	//value the healthbar needs to move TO.
	private float fillAmount;

	public Color fullColor;
	public Color lowColor;

	public float Value {
		set {
			fillAmount = mapValues (value, 0, 100f, 0, 1f);
		}
	}

	void Start () 
	{
		this.player = GameObject.Find ("PlayerShip").GetComponent<UnitPlayer> ();
	}

	void Update () 
	{
		handleHitPoints ();
	}
	/// <summary>
	/// Updates the healthbar.
	/// </summary>
	private void handleHitPoints()
	{
		Value = player.GetPlayerHitPoints ();
		content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		content.color = Color.Lerp (lowColor, fullColor, fillAmount);
	}

	/* 
	returns a value that the that the content.fillAmount can understand.
	f value = players hitpoints 						(GetPlayerHitPoints()).
	f inMin = lowest possible hitpoints					(0)
	f inMax = highest possible hitpoints				(100f)
	f outMin = lowest possible value on fillAmount		(0)
	f outMax = highest possible value on fillAmount		(1)
	*/
	private float mapValues(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
