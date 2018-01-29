using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollowshadows : MonoBehaviour {
	//path follow

	public EditorPathScript PathToFollow;

	public int CurrentWayPointID = 0;
	private float reachDistance = 1.0f;
	public string pathName;

	bool inshade;

	float currentspeed;

	float rotationSpeed;

	Vector3 last_position;
	Vector3 current_position;
	//
	// Use this for initialization
	void Start () {
		currentspeed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		inshade = GetComponentInChildren<DetectShade> ().inshade;


		float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);

		if (!inshade) {
			transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime * currentspeed);
		}
		var rotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*rotationSpeed);


		if (distance <= reachDistance) {
			CurrentWayPointID++;

		}

			if(CurrentWayPointID>=PathToFollow.path_objs.Count){
				CurrentWayPointID=0;
			}


		
	}
}
