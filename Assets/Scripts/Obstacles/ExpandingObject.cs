using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingObject : MonoBehaviour {

	public float rateFactor;
	public float magnitudeFactor;

	Vector3 startSize;
	Vector3 endSize;

	// Use this for initialization
	void Start () {
		startSize = transform.localScale;
		endSize = new Vector3 (startSize.x * magnitudeFactor, startSize.y * magnitudeFactor, startSize.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Lerp (startSize, endSize, (Mathf.Sin (rateFactor * Time.time) + 1.0f)/ 2.0f);
	}
}
