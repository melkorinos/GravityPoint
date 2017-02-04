using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	public float cameraSmoothing;
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			
			Vector3 nextPos = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, nextPos, Time.deltaTime * cameraSmoothing);
		} 
			//player = GameObject.FindGameObjectWithTag ("Player");
	}
}
