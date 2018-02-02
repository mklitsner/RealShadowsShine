using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCycler : MonoBehaviour {
    public Texture[] frames;
    int frameIdx = 0;
    float timeToUpdate = 0;


    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToUpdate)
        {
            this.GetComponent<Renderer>().material.mainTexture = frames[frameIdx];
            frameIdx = (frameIdx + 1) % frames.Length;
            timeToUpdate = Time.time + .1f;
        }
	}
}
