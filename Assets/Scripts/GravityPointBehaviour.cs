using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointBehaviour : MonoBehaviour {

	public float gravityForce;
	public float minAttractDistance;

	public bool clicked;

	GameObject player;
	Rigidbody2D playerRb;

	float distanceFromPlayer;

	// Use this for initialization
	void Start () {

		clicked = false;

		if (!GameManager.Instance.IsDead) {
			player = GameObject.FindGameObjectWithTag ("Player");
			playerRb = player.GetComponent<Rigidbody2D> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			distanceFromPlayer = (transform.position - player.transform.position).magnitude;
			//minimum attract distance
			if (distanceFromPlayer < minAttractDistance) {
				AttractPlayer ();
			}
		}
	}

	void AttractPlayer(){
		Vector2 direction = (transform.position - player.transform.position).normalized;
		playerRb.AddForce (gravityForce * direction);
	}
}
