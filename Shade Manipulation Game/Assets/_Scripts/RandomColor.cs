using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {
	Color currentColor;
	string state;
	// Use this for initialization
	void Start () {
		StartCoroutine (ChangeColor(1));
	}
	
	// Update is called once per frame
	void Update () {
		
//		state= GameObject.FindGameObjectWithTag("wanderer").GetComponent<DesertWandererAI> ().state;
		transform.GetComponent<MeshRenderer> ().material.color=currentColor;

//		if (state == "dead") {
//			currentColor = new Color (0, 0, 0);
//		}
	}



	private IEnumerator ChangeColor(float _duration){
		while (currentColor != Color.black) {
			currentColor = new Color (Random.Range (0.1f, 0.75f), Random.Range (0.1f, 0.75f), Random.Range (0.1f, 0.75f));

			yield return new WaitForSeconds (Random.Range(0.01f,0.5f));
		}
		
	}
}
