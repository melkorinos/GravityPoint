using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject levelTimeUI;
	public GameObject pauseMenuUI;
	public GameObject levelCompleteMenuUI;
	public GameObject medalsUI;
	public GameObject pointsRemainingUI;
	public Text finalGameTime;
	public Text goldTime;
	public Text silverTime;
	public Text bronzeTime;
	public Text pointsRemaining;

	Text levelTime;
	Vector4 leveltimes;

	// Use this for initialization
	void Start () {
		// init stuff
		levelTime = levelTimeUI.GetComponentInChildren<Text> ();
		pauseMenuUI.SetActive (false);
		levelCompleteMenuUI.SetActive (false);

		//get all level info
		leveltimes = LevelTimes.getLevelTimes(SceneManager.GetActiveScene().name);
		goldTime.text = leveltimes.x.ToString("0.00");
		silverTime.text = leveltimes.y.ToString("0.00");
		bronzeTime.text = leveltimes.z.ToString("0.00");
		pointsRemaining.text = "Holes Left : " + leveltimes.w.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.Instance.IsPlayerDead) {
			if (GameManager.Instance.IsNormalGameMode && (SpawnManager.Instance.firstClickTime != 0)) {
				DisplayGameTime ();
			} else {
				DisplayRemainingShots ();
			}
		}
	}

	public void AlternativeUI(){
		pointsRemainingUI.SetActive (true);
		medalsUI.SetActive (false);
	}
		
	public void ResumeGame (){
		pauseMenuUI.SetActive (false);
		levelCompleteMenuUI.SetActive (false);
	}

	public void PauseGame (){
		pauseMenuUI.SetActive (true);
	}

	public void DisplayGameTime(){ 
		float t = Time.timeSinceLevelLoad - SpawnManager.Instance.firstClickTime;
		levelTime.text = t.ToString ("0.00");
	}

	public void DisplayRemainingShots(){
		pointsRemaining.text = "Holes Left : " + SpawnManager.Instance.gravityPointsRemaining.ToString ();
	}

	//display end of level messages
	public void LevelComplete (){
		levelCompleteMenuUI.SetActive (true);
		if (GameManager.Instance.IsNormalGameMode) {
			
			float t = Time.timeSinceLevelLoad - SpawnManager.Instance.firstClickTime;
			finalGameTime.text = t.ToString ("0.00");

			//gold
			if (Time.timeSinceLevelLoad <= leveltimes.x)
				finalGameTime.color = new Vector4 (255, 215, 0, 1);
			//silver
			if (Time.timeSinceLevelLoad <= leveltimes.y)
				finalGameTime.color = new Vector4 (192, 192, 192, 0.85f);
			//bronze
			if (Time.timeSinceLevelLoad <= leveltimes.z)
				finalGameTime.color = new Vector4 (170, 83, 54, 0.7f);
		} else {
			
			//bronze
			if (SpawnManager.Instance.gravityPointsRemaining >= 0) {
				finalGameTime.color = new Vector4 (170, 83, 54, 0.7f);
				finalGameTime.text = "BRONZE";
			}
			//silver
			if (SpawnManager.Instance.gravityPointsRemaining >= 2) {
				finalGameTime.color = new Vector4 (192, 192, 192, 0.85f);
				finalGameTime.text = "SILVER";
			}
			//gold
			if (SpawnManager.Instance.gravityPointsRemaining >= 4) {
				finalGameTime.color = new Vector4 (255, 215, 0, 1);
				finalGameTime.text = "GOLD";
			}

		}
	}
}
