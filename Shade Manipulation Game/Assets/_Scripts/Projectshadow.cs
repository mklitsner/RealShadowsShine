using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectshadow : MonoBehaviour {

	Vector3 sunPosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		sunPosition = GameObject.Find ("sunTarget").transform.position;


		Vector3 targetPostition = new Vector3( sunPosition.x, 
			this.transform.position.y, 
			sunPosition.z ) ;
		this.transform.LookAt( targetPostition ) ;
		//print (sunPosition - transform.position);
		Debug.DrawRay (transform.position, (sunPosition - transform.position));


	}




}
