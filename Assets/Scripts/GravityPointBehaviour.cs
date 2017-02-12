using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointBehaviour : MonoBehaviour {

	public float gravityForce;

	GameObject player;
	Rigidbody2D playerRb;

	float distanceFromPlayer;

	// Use this for initialization
	void Start () {
		if (!GameManager.Instance.IsPlayerDead) {
			player = GameObject.FindGameObjectWithTag ("Player");
			playerRb = player.GetComponent<Rigidbody2D> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		// if game is active do things
		if (GameManager.Instance.IsGamePaused == true || GameManager.Instance.IsPlayerDead == true)
			return; 
			distanceFromPlayer = (transform.position - player.transform.position).magnitude;
				AttractPlayer (distanceFromPlayer);
	}

	void AttractPlayer(float distance){
		distance /= 4;
		if (distance <= 1)
			distance = 1;
		Vector2 direction = (transform.position - player.transform.position).normalized;
		playerRb.AddForce (gravityForce * direction/distance);
	}
}
