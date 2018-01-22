using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backText : MonoBehaviour {



	float colorTiming;
	Color initialColor;
	public Color activeColor;
	public string destination;
	// Use this for initialization
	void Start () {
		initialColor = transform.GetComponent<Text> ().color;
	}

	// Update is called once per frame
	void Update () {
		

	
		LoadSelection ();
	
		colorTiming = Mathf.PingPong (Time.time/5, 1);

		transform.GetComponent<Text> ().color=Color.Lerp(initialColor, activeColor,colorTiming);

	}
		



	void LoadSelection(){
		if (Input.GetKey ("space")) {
			SceneManager.LoadScene(destination);
		}







	}
}
