using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendFlower : MonoBehaviour {
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh skinnedMesh;
	int blendShapeCount;
	public int blendShapeSelected;
	public bool bloomed;
	public float rise;
	public float time;
	float blend;
	// Use this for initialization
	void Start () {



		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
		blendShapeCount = skinnedMesh.blendShapeCount; 
		transform.Translate (0, -rise, 0, 0);
		skinnedMeshRenderer.SetBlendShapeWeight (blendShapeSelected, 0);
	}
	
	// Update is called once per frame
	void Update () {
		bool inshade= GetComponentInChildren<DetectShade> ().inshade;

		if (inshade & !bloomed) {
			//start blooming until fully bloomed
			StartCoroutine(Bloom(100,time));	
		}

		if (bloomed && !inshade) {
			//if bloomed and not in shade, wait, and then shrink 
		}

	}

	IEnumerator Bloom(float bValue,float bTime)
	{
		
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / bTime)
		{
			transform.Translate (0, rise / bTime*Time.deltaTime,0,0);
			skinnedMeshRenderer.SetBlendShapeWeight (blendShapeSelected,Mathf.Lerp(blend,bValue,t));
			yield return bloomed=true;
		}

	}
		
}
