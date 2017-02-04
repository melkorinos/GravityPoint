using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _LoadLevel : MonoBehaviour {

	public string levelName;

	public void LoadScene (){
		SceneManager.LoadScene (levelName);
	}
}
