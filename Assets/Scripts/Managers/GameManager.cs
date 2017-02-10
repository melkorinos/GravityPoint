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
		SceneManager.sceneLoaded += LevelStart;
	}

	//***************************** END OF SINGLETON LOGIC   **********************

	public float respawnTime =1;
	[HideInInspector]
	public bool IsPlayerDead = true;
	[HideInInspector]
	public bool IsGamePaused = false;

	UIManager uiManager;

	void Update (){
		//pause and unpause
		if (Input.GetKeyDown("escape"))
		{
			if (IsGamePaused)
				ResumeLevel ();
			else
				PauseLevel ();
		}
	}
		
	 void LevelStart(Scene scene, LoadSceneMode mode){
		Time.timeScale = 1;
		if ((SceneManager.GetActiveScene().name != "Main Menu") && (SceneManager.GetActiveScene().name !="Levels")){
			IsPlayerDead = false;
			uiManager = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<UIManager> ();
			uiManager.levelCompleteMenuUI.SetActive (false);
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
		IsPlayerDead = true;
		StartCoroutine (RespawnPlayer (respawnTime));
	}
		
	IEnumerator RespawnPlayer (float respawnTime){
		yield return new WaitForSeconds (respawnTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		IsPlayerDead = false;
	}
}
