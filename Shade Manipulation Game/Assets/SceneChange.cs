using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
	GameObject wanderer;
	public string NextSceneName;
	// Use this for initialization
	void Start () {
		wanderer= GameObject.Find ("wanderer");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (wanderer.transform.GetComponent<DesertWandererAI> ().EndOfPath) {
			SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
		}
		
	}
}
