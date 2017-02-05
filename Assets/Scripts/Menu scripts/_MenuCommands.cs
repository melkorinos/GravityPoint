using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _MenuCommands : MonoBehaviour {

	public string loadOnEscape;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape")){
			SceneManager.LoadScene (loadOnEscape);
		}
	}
}
