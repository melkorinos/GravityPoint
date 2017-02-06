using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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


	Text leveltime;

	void Update (){
		if (!IsPlayerDead)
			DisplayGameTime ();
		
		if (Input.GetKeyDown("escape"))
		{
			SceneManager.LoadScene ("Main Menu");
		}
	}
		
	 void LevelStart(Scene scene, LoadSceneMode mode){
		Time.timeScale = 1;
		//LevelCompletedUI.SetActive (false);
		if ((SceneManager.GetActiveScene().name != "Main Menu") && (SceneManager.GetActiveScene().name !="Levels")){
			IsPlayerDead = false;
		} 
	}

	public void LevelComplete(){
		/*Time.timeScale = 0;
		IsGamePaused = true;
		LevelCompletedUI.SetActive (true);
		Text finalGametime = GameObject.Find ("Final Level Time").GetComponent<Text>();
		finalGametime.text = Time.timeSinceLevelLoad.ToString ("0.00");*/
	}

	public void OnGameOver (){
		IsPlayerDead = true;
		StartCoroutine (RespawnPlayer (respawnTime));
	}

	public void DisplayGameTime(){
		if (leveltime == null) 
			leveltime = GameObject.Find ("Level Time").GetComponent<Text> ();
		leveltime.text = Time.timeSinceLevelLoad.ToString ("0.00");
	}
		
	IEnumerator RespawnPlayer (float respawnTime){
		yield return new WaitForSeconds (respawnTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		IsPlayerDead = false;
	}
}
