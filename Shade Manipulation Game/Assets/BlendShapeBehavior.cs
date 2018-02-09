using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeBehavior : MonoBehaviour {
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh skinnedMesh;
	int blendShapeCount;
	public float blendOne = 0f;
	public float blendSpeed=1;


	// Use this for initialization
	void Start () {
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
		blendShapeCount = skinnedMesh.blendShapeCount; 
	}
	
	// Update is called once per frame
	void Update () {
		float heat = transform.parent.GetComponent<DesertWandererAI> ().heat;
		float blendheat=Mathf.Lerp (100, 0, heat);

		blendOne = Mathf.Lerp (blendOne, blendheat, Time.deltaTime*blendSpeed);
			


		skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);
		
	}
}
