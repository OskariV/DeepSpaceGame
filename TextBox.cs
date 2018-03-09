using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {
	public GameObject textBox;
	public Text Writing;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endLine;

	public CameraController player;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<CameraController> ();

		if (textLines != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		if (endLine == 0) {
			endLine = textLines.Length - 1;
		}
	}
	void Update(){

		Writing.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			currentLine += 1;
		}

		if (currentLine > endLine) {
			textBox.SetActive (false);
		}
	}
}