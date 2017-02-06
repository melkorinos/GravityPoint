using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _ButtonFunctions : MonoBehaviour {

	public string levelName;

	public void LoadMenuScene (){
		GameManager.Instance.IsPlayerDead = true;
		SceneManager.LoadScene (levelName);
	}

	public void LoadGameLevel () { 
		SceneManager.LoadScene (levelName);
		//GameManager.Instance.LevelStart ();
	}

	public void NextLevel (){
		int thisLevelIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (thisLevelIndex + 1);
		//GameManager.Instance.LevelStart ();
	}
}
