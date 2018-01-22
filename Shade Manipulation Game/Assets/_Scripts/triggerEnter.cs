using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnter : MonoBehaviour {
	public bool entered;






	void OnTriggerStay(Collider col){
		if (col.transform.tag == "wanderer") {
			entered = true;
		}
	}


}
