using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _ButtonFunctions : MonoBehaviour {

	public string levelName;

	public void LoadMenuScene (){
		SceneManager.LoadScene (levelName);
	}

	public void LoadGameLevel () { 
		SceneManager.LoadScene (levelName);
		//TODO start level manager call
		//GameManager.Instance.LevelStart ();
	}

	public void ResumeGame () {
		GameManager.Instance.ResumeGame ();
	}
}
