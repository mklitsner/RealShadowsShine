using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenWithHeat : MonoBehaviour {
	float heat;

	public Color currentColor;

	public Color startColor;
	public Color ScorchedColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<MeshRenderer> ().material.color=currentColor;
		heat = transform.parent.GetComponent<DesertWandererAI> ().heat;


		currentColor = Color.Lerp (startColor, ScorchedColor, heat);
		
	}
}
