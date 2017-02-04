using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// ***************************** SINGLETON LOGIC ***********************
	public static GameManager _instance;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null){
				GameObject go = new GameObject("GameManager");
				go.AddComponent<GameManager>();
			}

			return _instance;
		}
	}

	void Awake(){
		_instance = this;
	}

	//***************************** END OF SINGLETON LOGIC   **********************

	public float respawnTime =1;
	public bool IsDead = false;

	//float levelTime;

	public void OnGameOver (){
		StartCoroutine (RespawnPlayer (respawnTime));
	}

	public void LevelComplete(){
		//levelTime = Time.timeSinceLevelLoad;
		SceneManager.LoadScene ("Main Menu");
	}
		
	IEnumerator RespawnPlayer (float respawnTime){
		yield return new WaitForSeconds (respawnTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		IsDead = false;
	}
}
