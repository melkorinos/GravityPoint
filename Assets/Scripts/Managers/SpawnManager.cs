﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

	// ***************************** SINGLETON LOGIC ***********************
	public static SpawnManager _instance;

	public static SpawnManager Instance
	{
		get
		{
			if (_instance == null){
				GameObject go1 = new GameObject("SpawnManager");
				go1.AddComponent<SpawnManager>();
			}

			return _instance;
		}
	}

	void Awake(){
		_instance = this;
	}

	//***************************** END OF SINGLETON LOGIC   **********************

	public GameObject gravityPoint;
	[HideInInspector]
	public int gravityPointsRemaining;
	[HideInInspector]
	public float firstClickTime;

	GameObject spawnedGravityPoint;
	float clickTime;
	float clickHoldTime =0.25f;

	// Update is called once per frame
	void Update () {

		if (GameManager.Instance.IsGamePaused == true || GameManager.Instance.IsPlayerDead == true)
			return;
		// ***********************------------------PC CONTROLS--------------*****************************

		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

		if (Input.GetMouseButtonDown (0)) {
			
			//if there is a gravity point already
			if (spawnedGravityPoint != null) {
				if (IsClicked()){
					Destroy (spawnedGravityPoint);
				}else {
					Destroy (spawnedGravityPoint);
					CreateNewGravityPoint ();
				}
			}else {
				CreateNewGravityPoint ();
			}
		}

		if ((Input.GetMouseButtonUp (0)) && (Time.time - clickTime > clickHoldTime)) {
			Destroy (spawnedGravityPoint);
		}

		//***************************-------------MOBILE CONTROLS ---------------************************

		#elif UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				//if there is a gravity point already
				if (spawnedGravityPoint != null) {
					if (IsClicked()){
						Destroy (spawnedGravityPoint);
					}
					else {
						Destroy (spawnedGravityPoint);
						CreateNewGravityPoint ();
					}
				}
				else {
						CreateNewGravityPoint ();
				}
			}
		}
			
		//destroy on release
		if ((Input.GetTouch(0).phase == TouchPhase.Ended) && (Time.time - clickTime > clickHoldTime)) {
			Destroy (spawnedGravityPoint);
		}
		#endif
	}

	void CreateNewGravityPoint (){
		//if  no more points left to spawn
		if ((!GameManager.Instance.IsNormalGameMode) && (gravityPointsRemaining <= 0))
			return;

		clickTime = Time.time;
		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		Vector2 mousePos = Input.mousePosition;
		#elif UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		Vector2 mousePos = Input.GetTouch(0).position;
		#endif
		Vector2 spawnLocation = Camera.main.ScreenToWorldPoint (mousePos);
		spawnedGravityPoint =  Instantiate (gravityPoint, spawnLocation, Quaternion.identity) as GameObject;

		// one less point to spawn
		if (!GameManager.Instance.IsNormalGameMode) 
			gravityPointsRemaining--;
		// first gravity point for timer
		if (firstClickTime ==0)
			firstClickTime = Time.timeSinceLevelLoad;
		
	}

	bool IsClicked(){
		bool clicked = false;
		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		#elif UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
		#endif
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
		if (hit != null && hit.collider != null && hit.collider.tag == "Gravity Point") {
			clicked = true;
		}
		return clicked;
	}
}
