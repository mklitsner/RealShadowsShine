using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class littleoneText : MonoBehaviour {

	Color mainColor;
	public Color deadColor;
	// Use this for initialization
	void Start () {
	StartCoroutine (ChangeColor ());
	}

	// Update is called once per frame
	void Update () {
		


//		if (GameObject.FindGameObjectWithTag("wanderer") != null) {
//
//		} else {
//			mainColor=deadColor;
//		}

		transform.GetComponent<Text> ().color = mainColor;

	}


	private IEnumerator ChangeColor(){
		while (mainColor!=deadColor) {
			mainColor = new Color (Random.Range (0.1f, 0.75f), Random.Range (0.1f, 0.75f), Random.Range (0.1f, 0.75f));
			print ("colorchange");
			yield return new WaitForSeconds (Random.Range(0.01f,0.5f));
		}

	}

}
