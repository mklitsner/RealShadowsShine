using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintScript : MonoBehaviour {

	public float lifespan;
	public float lifeleft;
	public Vector3 direction;
	public int footprintSide;

	// Use this for initialization
	void Start () {
		lifeleft = lifespan;
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();

		if (lifeleft <= 0) {
			StartCoroutine(FadeTo(0.0f, 1.0f));

		}

		direction = transform.eulerAngles;
		
	}


	void Timer(){
		lifeleft = lifeleft - Time.deltaTime;
	}


	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			transform.GetComponent<SpriteRenderer>().material.color = newColor;
			yield return null;
		}
		Destroy (gameObject);
	}
}
