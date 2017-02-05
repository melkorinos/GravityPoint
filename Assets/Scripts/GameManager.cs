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
	[HideInInspector]
	public bool IsPlayerDead = false;
	public bool IsGamePaused = false;

	public GameObject pauseUI;
	float levelTime;

	void Update (){
		if (Input.GetKeyDown("escape"))
		{
			if (!IsGamePaused) {
				PauseGame ();
			} else {
				ResumeGame ();
			}
		}
	}
		
	public void OnGameOver (){
		IsPlayerDead = true;
		StartCoroutine (RespawnPlayer (respawnTime));
	}

	public void LevelComplete(){
		levelTime = Time.timeSinceLevelLoad;
		SceneManager.LoadScene ("Main Menu");
	}

	public void PauseGame(){
		Time.timeScale = 0;
		IsGamePaused = true;
		SpawnManager.Instance.enabled = false;
		pauseUI.SetActive (true);
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		IsGamePaused = false;
		SpawnManager.Instance.enabled = true;
		pauseUI.SetActive (false);
	}
		
	IEnumerator RespawnPlayer (float respawnTime){
		yield return new WaitForSeconds (respawnTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		IsPlayerDead = false;
	}
}
