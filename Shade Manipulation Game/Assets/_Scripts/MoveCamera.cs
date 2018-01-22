using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		triggerEnter south = transform.GetChild (0).transform.GetComponent<triggerEnter> ();
		triggerEnter north = transform.GetChild (1).transform.GetComponent<triggerEnter> ();
		triggerEnter west = transform.GetChild (2).transform.GetComponent<triggerEnter> ();
		triggerEnter east = transform.GetChild (3).transform.GetComponent<triggerEnter> ();

		if (south.entered) {
			this.transform.Translate (0, 0, -1	,Space.World);
		south.entered = false;
		}
		if (north.entered) {
			this.transform.Translate (0, 0, 1,Space.World);
		north.entered = false;
		}
		if (west.entered) {
			this.transform.Translate (-1, 0, 0,Space.World);
		west.entered = false;
		}
		if (east.entered) {
			this.transform.Translate (0, 0, 1,Space.World);
			east.entered = false;
		}
			


	}


}
