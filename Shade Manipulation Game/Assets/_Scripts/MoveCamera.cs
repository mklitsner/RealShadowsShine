using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public Transform focus;

	Vector3 cameraPos; 

	Vector3 focusPos;

	Vector3 relativePos;

	// Use this for initialization
	void Start () {

		cameraPos=this.transform.position;
		focusPos = focus.position;
		relativePos = new Vector3 (cameraPos.x - focusPos.x, cameraPos.y - focusPos.y, cameraPos.z - focusPos.z);
		
	}
	
	// Update is called once per frame
	void Update () {

		focusPos = focus.position;

		this.transform.position = new Vector3 (relativePos.x + focusPos.x, relativePos.y + focusPos.y, relativePos.z + focusPos.z);

	}
}
