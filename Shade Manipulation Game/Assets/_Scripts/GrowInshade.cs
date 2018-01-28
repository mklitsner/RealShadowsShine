using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowInshade : MonoBehaviour {


	public Vector3 minScale;
	public Vector3 maxScale;

	public float growSpeed = 2f;
	public float duration = 5f;
	float i = 0.0f;


	// Use this for initialization


	void Update(){
		bool inshade = transform.parent.GetComponent<DetectShade> ().inshade;

		float rate = (1.0f / duration) * growSpeed;

		if (inshade) {
			if (i < 1.0f) {
				i += Time.deltaTime * rate;
			}
		} else {
			if (i > 0.0f) {
				i -= Time.deltaTime * rate;
			}
		}
		transform.localScale = Vector3.Slerp (minScale, maxScale, i);
	}


		//if in shade long enough, stays grown
		

}
