using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject levelTimeUI;
	public GameObject pauseMenuUI;
	public GameObject levelCompleteMenuUI;
	public Text finalGameTime;

	Text levelTime;


	// Use this for initialization
	void Start () {
		levelTime = levelTimeUI.GetComponentInChildren<Text> ();
		pauseMenuUI.SetActive (false);
		levelCompleteMenuUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.Instance.IsPlayerDead)
			DisplayGameTime ();
	}
		
	public void ResumeGame (){
		pauseMenuUI.SetActive (false);
		levelCompleteMenuUI.SetActive (false);
	}

	public void PauseGame (){
		pauseMenuUI.SetActive (true);
	}

	public void DisplayGameTime(){ 
		levelTime.text = Time.timeSinceLevelLoad.ToString ("0.00");
	}

	public void LevelComplete (){
		levelCompleteMenuUI.SetActive (true);
		finalGameTime.text = Time.timeSinceLevelLoad.ToString ("0.00");
	}
}
