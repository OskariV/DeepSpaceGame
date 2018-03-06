using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Sceneloader : MonoBehaviour {
	

	public void LoadSceneOnClick(int sceneNo)
	{
		SceneManager.LoadScene(1);
	}

}