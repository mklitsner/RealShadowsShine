using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisibilityChecker : MonoBehaviour {

	public bool isVisibleToMainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vpPos = Camera.main.WorldToViewportPoint (this.transform.position);

		//print(C);

		isVisibleToMainCamera = vpPos.x > 0 && vpPos.x < 1 && vpPos.y > 0 && vpPos.y < 1;
			
	}
}
