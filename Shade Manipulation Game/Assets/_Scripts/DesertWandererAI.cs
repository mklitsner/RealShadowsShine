 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertWandererAI: MonoBehaviour {
	bool inshade;
	[Range(0, 1)]public float heat;//0-1
	[Range(0, 1)]public float tiredness;//0-1

	public GameObject footprint;
	public GameObject ghost;
	public GameObject self;
	int footprintSide=1;

	const string resting = "resting";
	const string dead ="dead";
	const string wandering ="wandering";
	const string sawSomething ="sawSomething";
	const string moveTowardSomething ="moveTowardSomething";
	public string state =wandering;

	float speed=1;
	float currentspeed;

	float rotationSpeed;
	float currentrotationSpeed;


	Vector3 globalRotation;
	float turnangle;
	float newturnangle;
	float turnTime;

	public float wanderingtime;
	float initialwanderingtime;

	public bool obstacle;
	int turningSide;

	float maxDistance;

	bool footprints;

	public Vector3 sunPosition;
	// Use this for initialization
	Vector3 spawnPos;

	//path follow

	public EditorPathScript PathToFollow;

	public int CurrentWayPointID;
	private float reachDistance = 1.0f;
	public string pathName;
	public bool EndOfPath;

	Vector3 last_position;
	Vector3 current_position;
	//



	void Start () {
		spawnPos = this.transform.position;
		StartCoroutine (FootPrintTiming (1));
		footprints = true;
		state = resting;
		rotationSpeed=1;

		SetState (wandering);
		footprintSide = 1;
		initialwanderingtime = 5;
		wanderingtime = initialwanderingtime;
		//StartCoroutine (FootPrintTiming (1));
		maxDistance = 5;

		speed = 2;
	


		//path follow
		PathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();
		last_position =transform.position;
	}







	// Update is called once per frame
	void Update () {





		DetectShade();

		//WHAT HAPPENS IF NOT IN THE SHADE

		if (state == wandering) {

			//PathFollow ();
			//path follow
			float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
			//transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime*currentspeed);

			var rotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * currentrotationSpeed);


			if (distance <= reachDistance) {
				CurrentWayPointID++;

			}
			if (CurrentWayPointID >= PathToFollow.path_objs.Count) {
				EndOfPath = true;
			}


			if (!inshade) {
				if (heat > 0.2f) {
					//if heated
					SetSpeed (0.2f / heat);
					MoveForward (currentspeed);
				} else {
					SetSpeed (1);
					MoveForward (currentspeed);
				}
			}


		//WHAT HAPPENS IF IN THE SHADE
		else if (inshade) {
				SetSpeed (1);
				MoveForward (currentspeed);
			

			}
			if (tiredness >= 1) {
				SetState (resting);
			}
		}

		if (state == resting) {
			if (heat <= 0 && tiredness <= 0) {
				SetState (wandering);
			}
		}

	

		SetHeat (0.005f,0.01f);
		SetTiredness (0.001f, 0.02f);
		StateIndicator ();

	}

	void SetSpeed(float _multiplier){
		currentspeed = speed * _multiplier;
		currentrotationSpeed = rotationSpeed * _multiplier;

	}



	void SetState(string _state){

		switch (_state) {
		case resting:
			//goes to sleep for a short amount of time
			state=resting;
			break;

		case dead:
			
			break;

		case wandering:
			//gets up and continues walking
			state = wandering;
			StartCoroutine (FootPrintTiming (1));
			break;

		case sawSomething:
			//perks up at the shade he saw
			wanderingtime=5;
			turnangle = transform.rotation.y;
			turnTime = 0;
			state = sawSomething;
			break;

		case moveTowardSomething:
			//perks up at the shade he saw
			break;
		}
	}




	void MoveForward(float _speed){
		//set wavering parameters
		//float newrotationFrequency = (heat + 1) * rotationFrequency;
		float _rotationFrequency =2;
		float _angle = Mathf.Cos (Time.time*_rotationFrequency) * currentrotationSpeed;

		transform.Translate (0, 0, _speed * Time.deltaTime);
		//waver
		transform.Rotate (0, _angle, 0);
	}

//	void TurnToHead(){
//		Vector3 _headDirection= transform.GetChild (0).transform.eulerAngles;
//		if (turnTime >= 1) {
//			turnTime = 1;
//		} else {
//			turnTime = turnTime + Time.deltaTime * rotationSpeed;
//			//turn a certain amount
//			Debug.DrawRay(transform.position,_headDirection);
//
//			transform.rotation = Quaternion.Lerp (Quaternion.Euler (0, turnangle, 0), Quaternion.Euler (0, _headDirection.y, 0), turnTime);
//		}
//	}





	int RandomSign(){
		if (Random.Range (0, 2) == 0) {
			return -1;
		} 
		return 1;
		
	}


//	void WanderingTimer(){
//		//wanders in a direction for a certain amount of time, 
//		//if its doesnt see anything or bump into its own foot prints, it turns;
//		wanderingtime=wanderingtime-Time.deltaTime;
//	}

	void ResetWanderingTimer(float _initialTime){
		if (wanderingtime <= 0) {
		wanderingtime = _initialTime;
		}

	}




//	void SearchForShade(){
//		bool seeShade =transform.GetChild (0).GetChild(0).GetComponent<ShadeSearcher> ().inshade;
//
//		if (seeShade) {
//			if (state != sawSomething) {
//				SetState (sawSomething);
//			}
//			print ("saw Shade");
//		}
//	}


	void DetectShade(){
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








	private IEnumerator FootPrintTiming(float _duration){


		while (state!=resting)
		{
			footprintSide=-1*footprintSide;
			Vector3 footprintposition = new Vector3 (transform.localPosition.x + 0.05f*footprintSide, transform.localPosition.y-0.5f,transform.localPosition.z);
			GameObject footprintclone = (GameObject)Instantiate(footprint,footprintposition,Quaternion.Euler(180+footprintSide*90,transform.localEulerAngles.y,90+90*footprintSide));
			footprintclone.GetComponent<FootprintScript> ().footprintSide = footprintSide;
			yield return new WaitForSeconds (_duration/(tiredness+1));
		}

	}




	void SetHeat(float _increaseheat,float _decreaseheat){
		if(inshade){
			if(heat<=0){
				heat = 0;
			}else{
				heat = heat-_decreaseheat;
				}
			}
		if(!inshade){
			if(heat>=1){
				heat = 1;
			}else{
				heat = heat +_increaseheat;
			}
		}
	}
		

	void SetTiredness(float _increasetiredness,float _decreasetiredness){
		if (state != resting && !inshade) {
			if (tiredness >= 1) {
				tiredness = 1;

			} else {
				tiredness = tiredness + _increasetiredness * heat;

			}
		}
		if (state == resting) {
				if (inshade) {
				//if he falls asleep in the shade, he wakes up and goes back to wandering
					if (tiredness <= 0) {
						state = wandering;
					} else {
						tiredness = tiredness - _decreasetiredness;
					}
				} else {
				//if sleeping in the sun and becomes too hot, he dies
				}
		}
	}
		
	void PathFollow(){
		//path follow
		float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
		//transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime*currentspeed);

		var rotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * currentrotationSpeed);


		if (distance <= reachDistance) {
			CurrentWayPointID++;

		}
	}


	void StateIndicator(){
		GetComponent<Renderer> ().material.color = new Color (heat, 0, 0);
	}


	void LookAhead(){
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;



		if (Physics.SphereCast (ray, 0.75f, out hit, maxDistance)) {
			obstacle = true;
		} else {
			obstacle = false;
		}
	}

	void Respawn(){



		GameObject selfClone=(GameObject)Instantiate(self,transform.position,Quaternion.identity);

		selfClone.transform.position = spawnPos;
		selfClone.transform.GetComponent<DesertWandererAI>().state = wandering;
		selfClone.transform.GetComponent<DesertWandererAI>().heat = 0;
		selfClone.transform.GetComponent<DesertWandererAI>().tiredness = 0;



	}






	}


	


