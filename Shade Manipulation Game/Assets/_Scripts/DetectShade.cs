using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShade : MonoBehaviour {

	public bool inshade;
	Vector3 sunPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			sunPosition = GameObject.Find ("sunTarget").transform.position;
			Ray ray = new Ray(transform.position, (sunPosition-transform.position));
			RaycastHit hit;
			//print (sunPosition - transform.position);
			Debug.DrawRay (transform.position, (sunPosition - transform.position));

			if (Physics.SphereCast (ray, 0.1f, out hit)) 
			{
				if (hit.transform.gameObject.name == "sunTarget"||hit.transform.gameObject.tag == "shadowman") {
					inshade = false;
				} else {
					inshade = true;
				}
			}
		}
		

}
