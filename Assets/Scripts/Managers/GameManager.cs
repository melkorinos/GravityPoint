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

		//Subscribe to scene loaded event
		SceneManager.sceneLoaded += LevelStart;
	}

	//***************************** END OF SINGLETON LOGIC   **********************

	public float respawnTime =1;
	[HideInInspector]
	public bool IsPlayerDead = true;
	[HideInInspector]
	public bool IsGamePaused = false;
	[HideInInspector]
	public bool IsNormalGameMode = true;

	UIManager uiManager;
	Vector4 leveltimes;

	void Update (){
		//pause and unpause
		if (Input.GetKeyDown ("escape") && !IsPlayerDead) {
			if (IsGamePaused)
				ResumeLevel ();
			else 
				PauseLevel ();
		}
	}
		
	 void LevelStart(Scene scene, LoadSceneMode mode){
		Time.timeScale = 1;
		if ((SceneManager.GetActiveScene().name [0].ToString () != "_")){
			IsPlayerDead = false;
			IsNormalGameMode = true;
			SpawnManager.Instance.firstClickTime = 0;
			uiManager = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<UIManager> ();

			// alternative mode stuff
			if ((PlayerPrefs.GetInt("Game Mode") == 1)) {
				IsNormalGameMode = false;
				leveltimes = LevelTimes.getLevelTimes (SceneManager.GetActiveScene ().name);
				SpawnManager.Instance.gravityPointsRemaining = Mathf.RoundToInt (leveltimes.w);
				uiManager.AlternativeUI ();
			}
		} 
	}

	public void ResumeLevel(){
		Time.timeScale = 1;
		IsGamePaused = false;
		uiManager.ResumeGame ();
	}

	public void PauseLevel(){
		IsGamePaused = true;
		Time.timeScale =0;
		uiManager.PauseGame ();
	}

	public void LevelComplete(){
		Time.timeScale = 0;
		IsGamePaused = true;
		uiManager.LevelComplete ();
	}

	public void OnGameOver (){
		Time.timeScale = 1;
		IsPlayerDead = true;
		StartCoroutine (RespawnPlayer (respawnTime));
	}
		
	IEnumerator RespawnPlayer (float respawnTime){
		yield return new WaitForSeconds (respawnTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		IsPlayerDead = false;
	}
}
