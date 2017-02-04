using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

	Rigidbody2D rb;

	void Update (){

		// TODO : put this somewhere else
		if (Input.GetKeyDown("escape"))
		{
			SceneManager.LoadScene("Main Menu");
		}

		//align look direction to velocity
		rb = GetComponent<Rigidbody2D> ();
		transform.right = rb.velocity;
	}

	void OnTriggerEnter2D (Collider2D other) {
		//on collission with wall, die
		if (other.tag == "Wall" || other.tag == "Obstacle") {
			GameManager.Instance.IsDead = true;
			GameManager.Instance.OnGameOver ();
			Destroy (this.gameObject);
		}

		if (other.tag == "Level End") {
			// level complete !
			GameManager.Instance.LevelComplete();
		}
	}
		

}
