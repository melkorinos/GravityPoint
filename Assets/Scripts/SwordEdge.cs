using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEdge : MonoBehaviour {

	public float speed;

	Vector2 startPoint;
	Vector2 endPoint;

	// Use this for initialization
	void Start () {
		// get the largest side size
		GetEndPoint();
		startPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.Lerp (startPoint, endPoint, (Mathf.Sin (speed * Time.time) + 1.0f)/ 2.0f);
	}

	void GetEndPoint(){
		Vector2 parentLocalScale = transform.parent.gameObject.transform.localScale;
		//dont know why .right works but works
		Vector3 parentDirection = transform.parent.gameObject.transform.right;

		float parentSize = (parentLocalScale.x > parentLocalScale.y) ? parentLocalScale.x : parentLocalScale.y;
		parentSize *= 0.9f;
	
		endPoint = transform.position + parentDirection * parentSize;
	}
		
}
