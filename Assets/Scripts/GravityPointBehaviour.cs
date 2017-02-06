using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointBehaviour : MonoBehaviour {

	public float gravityForce;
	public float minAttractDistance;
	[HideInInspector]
	public bool clicked;

	GameObject player;
	Rigidbody2D playerRb;

	float distanceFromPlayer;

	// Use this for initialization
	void Start () {
		clicked = false;

		if (!GameManager.Instance.IsPlayerDead) {
			player = GameObject.FindGameObjectWithTag ("Player");
			playerRb = player.GetComponent<Rigidbody2D> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
			distanceFromPlayer = (transform.position - player.transform.position).magnitude;
			//minimum attract distance
			if (distanceFromPlayer < minAttractDistance) {
				AttractPlayer (distanceFromPlayer);
			}
	}

	void AttractPlayer(float distance){
		distance /= 4;
		if (distance <= 1)
			distance = 1;
		Vector2 direction = (transform.position - player.transform.position).normalized;
		playerRb.AddForce (gravityForce * direction/distance);
	}
}
