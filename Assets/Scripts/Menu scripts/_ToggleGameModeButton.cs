﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _ToggleGameModeButton : MonoBehaviour {

	Text buttonText;

	// Use this for initialization
	void Start () {
		buttonText = GetComponentInChildren<Text> ();

		if ((PlayerPrefs.GetInt ("Game Mode") == 0)) {
			buttonText.text = "Normal Mode";
		} else {
			buttonText.text = "??? Mode";
		}

		Debug.Log (PlayerPrefs.GetInt ("Game Mode"));
	}

	public void ToggleGameMode (){
		

		if ((PlayerPrefs.GetInt ("Game Mode") == 0)) {
			PlayerPrefs.SetInt ("Game Mode",1);
			buttonText.text = "Spawn Mode";
		} else {
			PlayerPrefs.SetInt ("Game Mode", 0);
			buttonText.text = "Normal Mode";
		}

		Debug.Log (PlayerPrefs.GetInt ("Game Mode"));
	}
}
